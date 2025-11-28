using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVentaPanaderia.Pojos;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Esf;
using System.Drawing;
using System.Transactions;
using System.Security.Cryptography;

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
            string query = "insert into panes(idPan,nombre,descripcion,precio,stock,imagenPan,categoria)" +
                " values(@idPan,@nombre,@descripcion,@precio,@stock,@imagenPan,@categoria);";
            string query2 = "call spEmpleado_Auditoria(@idEmpleado);"; 
            MySqlTransaction tran = cn.BeginTransaction();

            MySqlCommand cmd = new MySqlCommand(query,cn); 
            MySqlCommand cmd2= new MySqlCommand(query2,cn);

            try
            {
                cmd.Parameters.AddWithValue("idPan", pan.idPan);
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
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spRegistrarEmpleado(@nombre,@apellidos,@usuario,@contrasena,@telefono);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                cmd.Parameters.AddWithValue("nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("apellidos", empleado.apellidos);
                cmd.Parameters.AddWithValue("usuario", empleado.usuario);
                cmd.Parameters.AddWithValue("contrasena", empleado.contrasena);
                cmd.Parameters.AddWithValue("telefono", empleado.telefono);
                cmd.ExecuteNonQuery();
                return true; 
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar el nuevo empleado"); 
            }
            finally
            {
                cmd.Dispose();
                cn.Close(); 
                cn.Dispose();
            }
        }

        public bool actualizarEmpleado(clsEmpleados empleado)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=localhost;database=ventasPan;uid=panes;pwd=root;";
            cn.Open();

            string query = "call spActualizarEmpleado(@idEmpleado,@nombre,@apellidos,@usuario,@telefono);";
            MySqlCommand cmd = new MySqlCommand(query, cn);
            try
            {
                cmd.Parameters.AddWithValue("idEmpleado", empleado.idEmpleado);
                cmd.Parameters.AddWithValue("nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("apellidos", empleado.apellidos);
                cmd.Parameters.AddWithValue("usuario", empleado.usuario);
                cmd.Parameters.AddWithValue("telefono", empleado.telefono);
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
                    auditoria.fecha=reader.GetDateTime(5);
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
