using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class ProductoService
    {
        private readonly ConnectionManager _conexion;
        private readonly ProductoRepository _repositorio;
        public ProductoService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ProductoRepository(_conexion);
        }
        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                  _conexion.Open();
                var productoAux = _repositorio.BuscarPorIdentificacion(producto.CodigoP);
                if (productoAux != null)
                {
                    return new GuardarProductoResponse($"Error de la Aplicacion: El producto ya se encuentra registrado!");
                }        
              
                _repositorio.Guardar(producto);
                _conexion.Close();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Producto> ConsultarTodos()
        {
            _conexion.Open();
            List<Producto> productos = _repositorio.ConsultarTodos();
            _conexion.Close();
            return productos;
        }
        public string Eliminar(string codigoP)
        {
            try
            {
                _conexion.Open();
                var producto = _repositorio.BuscarPorIdentificacion(codigoP);
                if (producto != null)
                {
                    _repositorio.Eliminar(producto);
                    _conexion.Close();
                    return ($"El registro {producto.NombreP} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {codigoP} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }
        public Producto BuscarxIdentificacion(string codigoP)
        {
            _conexion.Open();
            Producto producto = _repositorio.BuscarPorIdentificacion(codigoP);
            _conexion.Close();
            return producto;
        }
    }

    public class GuardarProductoResponse 
    {
        public GuardarProductoResponse(Producto producto)
        {
            Error = false;
            Producto = producto;
        }
        public GuardarProductoResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Producto Producto { get; set; }
    }
}