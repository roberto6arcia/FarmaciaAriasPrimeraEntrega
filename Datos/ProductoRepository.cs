using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class ProductoRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Producto> productos = new List<Producto>();
        public ProductoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Producto (CodigoP, NombreP, LaboratorioP, Fechadevencimiento, CantidadP) 
                                        values (@CodigoP,@NombreP,@LaboratorioP,@Fechadevencimiento,@CantidadP)";
                command.Parameters.AddWithValue("@CodigoP", producto.CodigoP);
                command.Parameters.AddWithValue("@NombreP", producto.NombreP);
                command.Parameters.AddWithValue("@LaboratorioP", producto.LaboratorioP);
                command.Parameters.AddWithValue("@Fechadevencimiento", producto.Fechadevencimiento);
                command.Parameters.AddWithValue("@CantidadP", producto.CantidadP);
                var filas = command.ExecuteNonQuery();
            }
        }
        public void Eliminar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from producto where CodigoP=@CodigoP";
                command.Parameters.AddWithValue("@CodigoP", producto.CodigoP);
                command.ExecuteNonQuery();
            }
        }
        public List<Producto> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Producto> productos = new List<Producto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from producto ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Producto producto = DataReaderMapToPerson(dataReader);
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }
        public Producto BuscarPorIdentificacion(string codigoP)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from producto where CodigoP=@CodigoP";
                command.Parameters.AddWithValue("@CodigoP", codigoP);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }
        private Producto DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Producto producto = new Producto();
            producto.CodigoP = (string)dataReader["CodigoP"];
            producto.NombreP = (string)dataReader["NombreP"];
            producto.LaboratorioP = (string)dataReader["LaboratorioP"];
            producto.Fechadevencimiento = (string)dataReader["Fechadevencimiento"];
            producto.CantidadP = (int)dataReader["CantidadP"];
            return producto;
        }
        
    }
}