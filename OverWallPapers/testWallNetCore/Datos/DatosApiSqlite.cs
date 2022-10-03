using OverWallPapers.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testWallNetCore.Datos.Interfaces;

namespace testWallNetCore.Datos
{
    
    public class DatosApiSqlite:IAgenteDatos
    {
        public string RutaDb;

        public DatosApiSqlite(string rutaDb)
        {
            RutaDb = rutaDb;

            //verificar is existe el archivo
            if(!File.Exists(RutaDb))
            {
                //si no existe se tiene que crear la base de datos con sus respectivas tablas  

                //creamos la base de datos 
                //string fuenteDatos = "Data Source=:memory:";
                string fuenteDatos = @$"URI=file:"+RutaDb;
                //string version = "SELECT SQLITE_VERSION()";

                //creamos la coneccion
                using (SQLiteConnection con = new SQLiteConnection(fuenteDatos))
                {
                    con.Open();

                    //creamos el comando para ejecutar la creacion de la tabla 
                    string crearTabla = $@"
create table FondosPantalla (Id integer PRIMARY KEY AUTOINCREMENT, Nombre varchar(200), Posicion int )
                                    ";

                    //ceramos el comando a ejecutar
                    using (SQLiteCommand cmd = con.CreateCommand())
                    {
                        //asignacion del texto al comando
                        cmd.CommandText = crearTabla;

                        //ejecucion del comando
                        cmd.ExecuteNonQuery();

                        //ahora crear la tabla de los monitores
                        string crearTablaMonitores = $@"create table Monitores (IdFondo int, Monitor int, FondoDePantalla varchar(400), foreign key (IdFondo) references FondosPantalla(Id) )";
                        cmd.CommandText=crearTablaMonitores;
                        cmd.ExecuteNonQuery();
                        
                    }
                }
                    
            }
            
            
        }

        public long? GuardarSet(WallPaperSet set)
        {
            //crear la coneccion a la base mongo
            //string fuenteDatos = "Data Source=:memory:";
            string fuenteDatos = @$"URI=file:" + RutaDb;
            //string version = "SELECT SQLITE_VERSION()";

            //creamos la coneccion
            using (SQLiteConnection con = new SQLiteConnection(fuenteDatos))
            {
                con.Open();


                
                //ceramos el comando a ejecutar
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        //1.- creamos la transaccion
                        cmd.CommandText = "begin transaction";

                        cmd.ExecuteNonQuery();


                        //2.- creamos el comando para ejecutar insercion / edicion en la tabla y recuperar su id 

                        //recuperar el id insertado del registro creado
                        long id = 0;

                        //si el set no cuenta con id quire decir que es nuevo
                        string crearTabla = "";
                        if(set.Id==null)
                        {
                            crearTabla = $@"
                            insert into FondosPantalla (Nombre, Posicion) 
                            values
                            ('{set.Nombre}',{((int)set.Posicion).ToString()});

                            select last_insert_rowid()
                                        ";

                            //asignacion del texto al comando
                            cmd.CommandText = crearTabla;

                            using SQLiteDataReader rdr = cmd.ExecuteReader();

                            
                            while (rdr.Read())
                            {
                                id = rdr.GetInt64(0);
                            }

                            rdr.Close();
                        }
                        else
                        {
                            //de lo contrario quiere decir que es una modificacion
                            string actualizar = $@"
                            update FondosPantalla 
                            set
                                Nombre='{set.Nombre}',
                                Posicion={((int)set.Posicion).ToString()}
                            where
                                Id={set.Id.ToString()};";

                            cmd.CommandText=actualizar;

                            cmd.ExecuteNonQuery();                            

                            id = (long)set.Id;

                            //eliminar los monitores previos registrados a este set para dar entrada a los nuevos

                            string eliminarMonitores = @$"
                            delete from Monitores where IdFondo={id.ToString()};
                            ";

                            cmd.CommandText = eliminarMonitores;
                            cmd.ExecuteNonQuery();
                        }
                        

                        //3.- ahora crear la tabla de los monitores
                        foreach (WallPaper wall in set.Monitores)
                        {
                            string crearTablaMonitores = $@"
                            insert into Monitores (IdFondo, Monitor, FondoDePantalla )
                            values  
                            ({id.ToString()},{wall.Monitor},'{wall.FondoDePantalla}')
                            ";
                            cmd.CommandText = crearTablaMonitores;
                            cmd.ExecuteNonQuery();
                        }

                        //4.- comitear cambios
                        cmd.CommandText = "COMMIT TRANSACTION";

                        cmd.ExecuteNonQuery();

                        return id;

                    }
                    catch(Exception ex)
                    {
                        cmd.CommandText= "ROLLBACK TRANSACTION";

                        cmd.ExecuteNonQuery();

                        throw new Exception(ex.Message);
                    }

                }

                return 0;
            }

            
        }

        public List<WallPaperSet> ConsultarSets()
        {
            string fuenteDatos = @$"URI=file:" + RutaDb;

            //creamos la coneccion
            using (SQLiteConnection con = new SQLiteConnection(fuenteDatos))
            {
                con.Open();

                //ceramos el comando a ejecutar
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        //1.- creamos la transaccion
                        cmd.CommandText = "select Id, Nombre, Posicion from FondosPantalla";

                        using SQLiteDataReader rdr = cmd.ExecuteReader();

                        //crear la lista a devolver
                        List<WallPaperSet> sets = new List<WallPaperSet>();

                        while (rdr.Read())
                        {
                            WallPaperSet set= new WallPaperSet();
                            set.Nombre = (string)rdr["Nombre"];
                            set.Id = rdr["Id"].GetType().Equals(typeof(DBNull))?0:(Int64)rdr["Id"];
                            set.Posicion=(DesktopWallpaperPosition)(int)rdr["Posicion"];

                            sets.Add(set);
                        }

                        rdr.Close();

                        return sets;
                       

                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }

            return null;
        }

        public WallPaperSet ConsultarSet(Int64 id)
        {
            string fuenteDatos = @$"URI=file:" + RutaDb;

            //crear el set a devolver
            WallPaperSet set = new WallPaperSet();
            //creamos la coneccion
            using (SQLiteConnection con = new SQLiteConnection(fuenteDatos))
            {
                con.Open();

                //ceramos el comando a ejecutar
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    //1.- recuperamos el objeto a consultar
                    cmd.CommandText = @$"select * from FondosPantalla where Id ={id.ToString()}";

                    using SQLiteDataReader rdr = cmd.ExecuteReader();

                    
                    set.Monitores = new List<WallPaper>();
                    while (rdr.Read())
                    {
                        set.Nombre = (string)rdr["Nombre"];
                        set.Id = rdr["Id"].GetType().Equals(typeof(DBNull)) ? 0 : (Int64)rdr["Id"];
                        set.Posicion = (DesktopWallpaperPosition)(int)rdr["Posicion"];

                    }

                    rdr.Close();


                    //2.- obtener los monitores correspondientes
                    List<WallPaper> monitores = new List<WallPaper>();

                    cmd.CommandText = @$"select * from Monitores where IdFondo ={id.ToString()}";

                    using SQLiteDataReader rdrx = cmd.ExecuteReader();

                    while (rdrx.Read())
                    {
                        WallPaper wall = new WallPaper();
                        wall.FondoDePantalla = (string)rdrx["FondoDePantalla"];
                        wall.Monitor = (int)rdrx["Monitor"];
                        set.Monitores.Add(wall);
                    }

                    rdrx.Close();


                }
                
            }

            return set;
        }

        public bool EliminarSet(long id)
        {
            string fuenteDatos = @$"URI=file:" + RutaDb;

            
            //creamos la coneccion
            using (SQLiteConnection con = new SQLiteConnection(fuenteDatos))
            {
                con.Open();

                //ceramos el comando a ejecutar
                using (SQLiteCommand cmd = con.CreateCommand())
                {
                    //1.- eliminamos los monitores dependientes
                    string eliminarMonitores = @$"
                            delete from Monitores where IdFondo={id.ToString()};
                            ";

                    cmd.CommandText = eliminarMonitores;
                    cmd.ExecuteNonQuery();


                    //2.- eliminamos el set de la tabla principal
                    eliminarMonitores = @$"
                            delete from FondosPantalla where Id={id.ToString()};
                            ";

                    cmd.CommandText = eliminarMonitores;
                    cmd.ExecuteNonQuery();
                }

            }
            return true;
        }
    }
}
