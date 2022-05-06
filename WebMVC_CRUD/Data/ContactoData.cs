using WebMVC_CRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebMVC_CRUD.Data {
    public class ContactoData {
        public List<ContactoModel> Listar() { 
            var lista     = new List<ContactoModel>();
            var conexion = new DbConnection();

            using (var con = new SqlConnection(conexion.GetCadenaSQL())) { 
                con.Open();

                SqlCommand cmd = new SqlCommand("Listar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        lista.Add(new ContactoModel {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre     = dr["Nombre"].ToString(),
                            Telefono   = dr["Telefono"].ToString(),
                            Correo     = dr["Correo"].ToString()
                        });
                    }
                }    
            }

            return lista;
        }

        public ContactoModel Obtener(int id) { 
            var contacto = new ContactoModel();
            var conexion = new DbConnection();

            using (var con = new SqlConnection(conexion.GetCadenaSQL())) { 
                con.Open();

                SqlCommand cmd = new SqlCommand("ObtenerContacto", con);
                cmd.Parameters.AddWithValue("IdContacto", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        contacto.Nombre     = dr["Nombre"].ToString();
                        contacto.Telefono   = dr["Telefono"].ToString();
                        contacto.Correo     = dr["Correo"].ToString();
                    }
                }    
            }

            return contacto;
        }

        public bool Guardar(ContactoModel contactoModel) {
            bool resp;

            try {
                var conexion = new DbConnection();

                using (var con = new SqlConnection(conexion.GetCadenaSQL())){
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GuardarContacto", con);

                    cmd.Parameters.AddWithValue("Nombre", contactoModel.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", contactoModel.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contactoModel.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resp = true;
                }
            } catch (Exception e) {
                string error = e.Message;
                resp = false;
            }

            return resp;
        }

        public bool Editar(ContactoModel contactoModel) {
            bool resp;

            try {
                var conexion = new DbConnection();

                using (var con = new SqlConnection(conexion.GetCadenaSQL())){
                    con.Open();

                    SqlCommand cmd = new SqlCommand("EditarContacto", con);

                    cmd.Parameters.AddWithValue("IdContacto", contactoModel.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", contactoModel.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", contactoModel.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contactoModel.Correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resp = true;
                }
            } catch (Exception e) {
                string error = e.Message;
                resp = false;
            }

            return resp;
        }

        public bool Eliminar(int idContacto) {
            bool resp;

            try {
                var conexion = new DbConnection();

                using (var con = new SqlConnection(conexion.GetCadenaSQL())){
                    con.Open();

                    SqlCommand cmd = new SqlCommand("EliminarContacto", con);

                    cmd.Parameters.AddWithValue("IdContacto", idContacto);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    resp = true;
                }
            } catch (Exception e) {
                string error = e.Message;
                resp = false;
            }

            return resp;
        }
    }
}
