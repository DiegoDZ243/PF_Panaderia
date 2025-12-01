using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using PuntoDeVentaPanaderia.Pojos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PuntoDeVentaPanaderia.Backend
{
    public class clsDaoPanaderia
    {
        #region CRUD_PANES  
        public List<clsPanes> obtenerPanes()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "select * from panes;"; 
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                MySqlDataReader reader=cmd.ExecuteReader();
                List<clsPanes> panes = new List<clsPanes>();
                while (reader.Read())
                {
                    clsPanes pan = new clsPanes();
                    pan.idPan = reader.GetInt32(0); 
                    pan.nombre = reader.GetString(1);
                    pan.descripcion = reader.GetString(2);
                    pan.precio = reader.GetDecimal(3);
                    pan.stock = reader.GetInt32(4);
                    pan.direccionImg = reader.GetString(5); 
                    pan.categoria = reader.GetString(6);
                    pan.descontinuado=reader.GetBoolean(7);
                    panes.Add(pan); 
                }
                return panes; 

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al conectarse al servidor");
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose(); 
            }

        }

        public bool registrarPan(clsPanes pan, int idEmpleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString= "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "insert into panes(nombre,descripcion,precio,stock,imagenPan,categoria)" +
                " values(@nombre,@descripcion,@precio,@stock,@imagenPan,@categoria);";
            string query2 = "call spEmpleado_Auditoria(@idEmpleado);"; 
            MySqlTransaction tran = cn.BeginTransaction();

            MySqlCommand cmd = new MySqlCommand(query,cn); 
            MySqlCommand cmd2= new MySqlCommand(query2,cn);

            cmd.Transaction = tran;
            cmd2.Transaction = tran;

            try
            {
                cmd.Parameters.AddWithValue("nombre", pan.nombre);
                cmd.Parameters.AddWithValue("descripcion", pan.descripcion);
                cmd.Parameters.AddWithValue("precio", pan.precio);
                cmd.Parameters.AddWithValue("stock", pan.stock); 
                cmd.Parameters.AddWithValue("imagenPan",pan.direccionImg);
                cmd.Parameters.AddWithValue("categoria", pan.categoria); 
                cmd.ExecuteNonQuery();

                cmd2.Parameters.AddWithValue("idEmpleado",idEmpleado); 
                cmd2.ExecuteNonQuery();

                tran.Commit();
                return true; 

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex; 

            }
            finally
            {
                tran.Dispose();
                cmd2.Dispose(); 
                cmd.Dispose();
                cn.Close();
                cn.Dispose(); 
            }

        }

        public bool descontinuarPan(int panId,int idEmpleado)
        {

            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "update panes set descontinuado=true where idPan=@panId;";
            string query2 = "call spEmpleado_Auditoria(@idEmpleado);";
            MySqlTransaction tran = cn.BeginTransaction();
            MySqlCommand cmd=new MySqlCommand(query,cn);
            MySqlCommand cmd2 = new MySqlCommand(query2, cn);
            cmd.Transaction = tran;
            cmd2.Transaction = tran;
            try
            {
                cmd.Parameters.AddWithValue("panId", panId); 
                cmd.ExecuteNonQuery ();

                cmd2.Parameters.AddWithValue("idEmpleado",idEmpleado);
                cmd2.ExecuteNonQuery();

                tran.Commit(); 
                return true; 
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex; 
            }
            finally
            {
                tran.Dispose();
                cn.Close(); 
                cn.Dispose();
                cmd.Dispose();
                cmd2.Dispose ();
            }
        }

        public bool actualizarPan(clsPanes pan, int idEmpleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "update panes " +
                "set nombre=@nombre_nuevo," +
                " descripcion=@descripcion_nueva," +
                " precio=@precio_nuevo," +
                " stock=@stock_nuevo," +
                " imagenPan=@imagenPan_nueva," +
                " categoria=@categoria_nueva" +
                " where idPan=@idPan;";

            string query2 = "call spEmpleado_Auditoria(@idEmpleado);"; 
            MySqlTransaction tran = cn.BeginTransaction();

            MySqlCommand cmd=new MySqlCommand(query,cn);

            MySqlCommand cmd2 = new MySqlCommand(query2, cn);
            cmd.Transaction = tran;
            cmd2.Transaction = tran;
            try
            {
                cmd.Parameters.AddWithValue("nombre_nuevo", pan.nombre);
                cmd.Parameters.AddWithValue("descripcion_nueva", pan.descripcion);
                cmd.Parameters.AddWithValue("precio_nuevo", pan.precio);
                cmd.Parameters.AddWithValue("stock_nuevo", pan.stock);
                cmd.Parameters.AddWithValue("imagenPan_nueva", pan.direccionImg);
                cmd.Parameters.AddWithValue("categoria_nueva", pan.categoria);
                cmd.Parameters.AddWithValue("idPan", pan.idPan); 
                cmd.ExecuteNonQuery();

                cmd2.Parameters.AddWithValue("idEmpleado", idEmpleado);
                cmd2.ExecuteNonQuery(); 
                tran.Commit();
                return true;
            }
            catch(Exception ex)
            {
                tran.Rollback(); 
                throw ex; 
            }
            finally
            {
                tran.Dispose();
                cmd2.Dispose(); 
                cmd.Dispose ();
                cn.Close();
                cn.Dispose();
            }

        }

        #endregion

        public List<string> ObtenerCategoriasDesdeDB()
        {
            List<string> categorias = new List<string>();
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            // Consulta los valores del ENUM
            string query = "SHOW COLUMNS FROM panes WHERE Field = 'categoria';";
            MySqlCommand cmd = new MySqlCommand(query, cn);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    string enumDefinition = reader.GetString("Type");

                    // Se usa expresion regular pa sacar los valores
                    Match match = Regex.Match(enumDefinition, @"enum\((.+)\)");

                    if (match.Success)
                    {
                        string rawValues = match.Groups[1].Value.Replace("'", "");
                        categorias = rawValues.Split(',').ToList(); //Dividir por comas, pa hacerlo lista
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las categorías ENUM de la base de datos.", ex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return categorias;
        }

        public string GuardarImagenEnProyecto(string rutaOrigen)

        {
            //El sufijo será la un directorio anterior a de \bin. Se encontrará al mismo nivel que las
            //carpetas de backend, frontend y pojos (Es el único cambio realizado al dirección)
            string root = Directory.GetParent(Application.StartupPath).Parent.FullName;
            // Crea la ruta de destino
            string directorioDestino = Path.Combine(root, "panesImg"); // va dentro del proyecto

            if (!Directory.Exists(directorioDestino))
            {
                Directory.CreateDirectory(directorioDestino); // Pa crearla por si no existe
            }
            string nombreArchivo = Path.GetFileName(rutaOrigen);
            string rutaDestinoCompleta = Path.Combine(directorioDestino, nombreArchivo);

            //Pregunta si el archivo existe en la ruta destino antes de copiar
            if (!File.Exists(Path.Combine("panesImg",nombreArchivo)))
            {
                try
                {
                    File.Copy(rutaOrigen, rutaDestinoCompleta, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Advertencia: No se pudo copiar la imagen de {rutaOrigen}. Error: {ex.Message}");
                }
            }
            // Devolvemos la ruta absoluta
            return rutaDestinoCompleta;

        }

        public List<clsPanes> obtenerPanesPorCategoria(string categoria)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "select idPan, nombre, descripcion, precio, stock, imagenPan, categoria from panes where categoria = @categoria AND (descontinuado IS NULL OR descontinuado = false);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@categoria", categoria);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                List<clsPanes> panes = new List<clsPanes>();
                while (reader.Read())
                {
                    clsPanes pan = new clsPanes();
                    pan.idPan = reader.GetInt32(0);
                    pan.nombre = reader.GetString(1);
                    pan.descripcion = reader.GetString(2);
                    pan.precio = reader.GetDecimal(3);
                    pan.stock = reader.GetInt32(4);
                    pan.direccionImg = reader.GetString(5);
                    pan.categoria = reader.GetString(6);
                    panes.Add(pan);
                }
                return panes;

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error al obtener los panes de la categoría {categoria}: {ex.Message}");
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        #region CRUD_EMPLEADOS
        public List<clsEmpleados> obtenerEmpleados()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spMostrarEmpleados;";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                List<clsEmpleados> empleados = new List<clsEmpleados>();
                while (reader.Read())
                {
                    clsEmpleados empleado = new clsEmpleados();
                    empleado.idEmpleado = reader.GetInt32(0);
                    empleado.nombre = reader.GetString(1);
                    empleado.apellidos = reader.GetString(2);
                    empleado.usuario = reader.GetString(3);
                    empleado.telefono=reader.GetString(4);
                    empleado.admin = reader.GetBoolean(5); 
                    empleados.Add(empleado);
                }
                return empleados;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al conectarse al servidor");
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Revisa las credenciales del empleado que utilizará el sistema
        /// </summary>
        /// <param name="usuario">Usuario único del empleado</param>
        /// <param name="contrasena">Contraseña del empleado</param>
        /// <returns>Retorna el id del empledo si sus credenciales son correctas; retorna -1 en caso contrario</returns>
        public clsEmpleados autentificarEmpleado(string usuario, string contrasena)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spLoginEmpleado(@usuario,@contrasena);"; 
            MySqlCommand cmd = new MySqlCommand(query, cn);

            try
            {
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("contrasena", contrasena); 
                MySqlDataReader reader = cmd.ExecuteReader();
                clsEmpleados empleado= new clsEmpleados();
                if (reader.HasRows)
                {
                    reader.Read(); 
                    empleado.idEmpleado=(reader.IsDBNull(0))?-1:reader.GetInt32(0);
                    empleado.nombre = (reader.IsDBNull(1)) ? "" : reader.GetString(1);
                    empleado.admin = reader.GetBoolean(2);
                    return empleado;
                }

                return null; 

            }
            catch (Exception ex)
            {
                throw ex; 

            }
            finally
            {
                cmd.Dispose(); 
                cn.Close();
                cn.Dispose();
            }
        }

        public bool registrarEmpleado(clsEmpleados empleado)
        {
            string connectionString = "server=localhost;database=ventas;uid=root;pwd=root;";

            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                try
                {
                    cn.Open();

                    string query = "call spRegistrarEmpleado(@nombre,@apellidos,@usuario,@contrasena,@telefono,@admin);";

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", empleado.apellidos);
                        cmd.Parameters.AddWithValue("@usuario", empleado.usuario);
                        cmd.Parameters.AddWithValue("@contrasena", empleado.contrasena);
                        cmd.Parameters.AddWithValue("@telefono", empleado.telefono);
                        cmd.Parameters.AddWithValue("@admin", empleado.admin);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocurrió un error al registrar el nuevo empleado: " + ex.Message);
                }
            }
        }

        public bool actualizarEmpleado(clsEmpleados empleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spActualizarEmpleado(@idEmpleado,@nombre,@apellidos,@usuario,@telefono,@admin);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                cmd.Parameters.AddWithValue("idEmpleado", empleado.idEmpleado);
                cmd.Parameters.AddWithValue("nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("apellidos", empleado.apellidos);
                cmd.Parameters.AddWithValue("usuario", empleado.usuario);
                cmd.Parameters.AddWithValue("telefono", empleado.telefono);
                cmd.Parameters.AddWithValue("admin", empleado.admin);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar los datos del empleado");
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public bool desactivarEmpleado(int idEmpleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spDesactivarEmpleado(@idEmpleado);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                cmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
                
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al dar de baja al empleado");
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public bool EsAdministrador(int idEmpleado)
        {
            bool isAdmin = false;
            string connectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            string query = "call spEsAdmin(@idEmpleado);"; 
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("idEmpleado", idEmpleado);
                        MySqlDataReader result = cmd.ExecuteReader(); 

                        if (result.HasRows)
                        {
                            result.Read();
                            isAdmin = result.GetBoolean(0);
                            return isAdmin; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex; 
                }
            }
            return isAdmin;
        }

        #endregion

        public bool registrarOrden(List<clsDetalleOrden> productos, int idEmpleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            MySqlTransaction trans = cn.BeginTransaction();
            
            try
            {
                string query1 = "select fnCrearOrden(@idEmpleado);";
                MySqlCommand cmd1 = new MySqlCommand(query1, cn);
                cmd1.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                MySqlDataReader reader = cmd1.ExecuteReader();

                reader.Read(); 
                int idOrden=reader.GetInt32(0);
                
                cmd1.Dispose();
                reader.Close();
                
                foreach(clsDetalleOrden p in productos){
                    string query2 = "insert into detalleOrden(idPan,idOrden,unidades,precio) " +
                        "values(@idPan, @idOrden,@unidades,@precio);";
                    MySqlCommand cmd2 = new MySqlCommand(query2, cn);

                    cmd2.Parameters.AddWithValue("idPan", p.idPan);
                    cmd2.Parameters.AddWithValue("idOrden", idOrden);
                    cmd2.Parameters.AddWithValue("unidades", p.unidades);
                    cmd2.Parameters.AddWithValue("precio", p.precio);
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose(); 
                }
                trans.Commit();
                return true; 
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;

            }
            finally
            {
                cn.Close();
                cn.Dispose(); 
            }
        }

        public List<clsReporteVenta> mostrarReporteVentas(DateTime fechaInicio, DateTime FechaFin)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "call spReporteDeVenta(@fechaInicio,@fechaFinal);";
            MySqlCommand cmd =new MySqlCommand(query, cn);
            try
            {   
                cmd.Parameters.AddWithValue("fechaInicio",fechaInicio);
                cmd.Parameters.AddWithValue("fechaFinal", FechaFin); 
                MySqlDataReader reader= cmd.ExecuteReader();

                List<clsReporteVenta> ventas= new List<clsReporteVenta>();
              
                while (reader.Read())
                {
                    clsReporteVenta venta=new clsReporteVenta();
                    venta.clave = reader.GetInt32(0);
                    venta.nombre = reader.GetString(1);
                    venta.unidades = reader.GetInt32(2);
                    venta.monto = reader.GetDecimal(3);
                    ventas.Add(venta); 
                }
                return ventas; 
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al recuperar las ventas del sistema"); 
            }
            finally //Git
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose(); 
            }
        }
        /// <summary>
        /// Función que regresa la lista de reportes de ventas para los mes 1 y 2 especificados
        /// </summary>
        /// <param name="mes1">Mes 1 a comparar</param>
        /// <param name="mes2">Mes 2 a comparar</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<clsReporteVentaMes> mostrarReporteVentasMeses(DateTime mes1, DateTime mes2)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "call spReporteDeVentaMeses(@mes1,@mes2);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                cmd.Parameters.AddWithValue("mes1", mes1);
                cmd.Parameters.AddWithValue("mes2", mes2);
                MySqlDataReader reader = cmd.ExecuteReader();

                List<clsReporteVentaMes> ventas = new List<clsReporteVentaMes>();

                while (reader.Read())
                {
                    clsReporteVentaMes venta = new clsReporteVentaMes();
                    venta.clave = reader.GetInt32(0);
                    venta.nombre = reader.GetString(1);
                    venta.precio = reader.GetDecimal(2);
                    venta.ventasMes1 = reader.GetDecimal(3);
                    venta.ventasMes2 = reader.GetDecimal(4);
                    ventas.Add(venta);
                }
                return ventas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al recuperar las ventas del sistema");
            }
            finally //Git
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //Todavía falta aplicar este método para mostrar las auditorias
        /// <summary>
        /// Función que permite mostrar los movimientos realizados en la tabla de panes por los 
        /// empleados.
        /// </summary>
        /// <returns>Retorna una lista con todos los movimientos realizados en la tabla de panes</returns>
        /// <exception cref="Exception"></exception>
        public List<clsAuditoria> obtenerAuditorias()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();
            string query = "select * from vwAuditorias;";
            MySqlCommand cmd = new MySqlCommand(query,cn);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                List<clsAuditoria> auditorias=new List<clsAuditoria>();

                while (reader.Read())
                {
                    clsAuditoria auditoria = new clsAuditoria();
                    auditoria.nombre=reader.GetString(0);
                    auditoria.cambio=reader.GetString(1);
                    auditoria.usuario = reader.GetString(2);
                    auditoria.precioAnterior = reader.GetDecimal(3); 
                    auditoria.precioNuevo = reader.GetDecimal(4);
                    auditoria.fecha=reader.GetString(5);
                    auditorias.Add(auditoria);

                }
                return auditorias;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al recuperar las" +
                    " auditorias. Intentelo nuevamente más tarde");
            }
            finally
            {
                cmd.Dispose(); 
                cn.Close();
                cn.Dispose();
            }
        }
    }
}
