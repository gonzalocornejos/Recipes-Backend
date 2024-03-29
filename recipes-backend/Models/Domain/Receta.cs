﻿namespace recipes_backend.Models.Domain
{
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Dtos.Utilizados;
    using recipes_backend.Models.ORM;
    using System;

    public class Receta : Entity
    {
        private Usuario _usuario;
        private string _nombre;
        private string _descripcion;
        private string _foto;
        private int _porciones;
        private int _cantidadPersonas;
        private readonly List<RecetaTipoPlato> _tiposPlato;
        private readonly List<Foto> _fotos;
        private readonly List<Utilizados> _ingredientes;
        private readonly List<Paso> _pasos;
        private readonly List<Calificacion> _calificaciones;
        private readonly List<Favorita> _favorito;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public int Porciones
        {
            get { return _porciones; }
            set { _porciones = value; }
        }

        public int CantidadPersonas
        {
            get { return _cantidadPersonas; }
            set { _cantidadPersonas = value; }
        }

        public IReadOnlyList<RecetaTipoPlato> TiposPlato => _tiposPlato.ToList();

        public IReadOnlyList<Foto> Fotos => _fotos.ToList();

        public IReadOnlyList<Utilizados> Ingredientes => _ingredientes.ToList();

        public IReadOnlyList<Paso> Pasos => _pasos.ToList();

        public IReadOnlyList<Calificacion> Calificaciones => _calificaciones.ToList();

        public IReadOnlyList<Favorita> Favorito => _favorito.ToList();

        protected Receta()
        {
            _tiposPlato = new List<RecetaTipoPlato>();
            _fotos = new List<Foto>();
            _ingredientes = new List<Utilizados>();
            _pasos = new List<Paso>();
            _calificaciones = new List<Calificacion>();
            _favorito = new List<Favorita>();
        }

        public Receta(Usuario usuario, string nombre, string descripcion, string foto,
            int porciones, int cantidadPersonas) : this()
        {
            Usuario = usuario;
            Nombre = nombre;
            Descripcion = descripcion;
            Foto = foto;
            Porciones = porciones;
            CantidadPersonas = cantidadPersonas;
        }

        public void AgregarPasos(List<PasoDTO> pasosDTO)
        {
            foreach(var paso in pasosDTO)
            {
                var newPaso = new Paso(this, paso.Number, paso.Descripcion, paso.Titulo);
                newPaso.AddMultimedias(paso.Media);
                _pasos.Add(newPaso);
            }
        }

        public void AgregarTiposPlato(List<TipoPlato> tipoPlatos)
        {
            foreach(var tipo in tipoPlatos)
            {
                _tiposPlato.Add(new RecetaTipoPlato(this,tipo));
            }
        }

        public void AgregarIngredientes(List<UtilizadoDTO> ingredientes)
        {
            foreach (var ingrediente in ingredientes)
            {
                _ingredientes.Add(new Utilizados(this,ingrediente.Ingrediente,ingrediente.Cantidad,ingrediente.Unidad,ingrediente.Descripcion));
            }
        }

        public void EditarReceta(Usuario usuario, string nombre, string descripcion, string foto,
            int porciones, int cantidadPersonas, List<PasoDTO> pasosDTO, List<TipoPlato> tipoPlatos, List<UtilizadoDTO> ingredientes)
        {
            _pasos.Clear();
            _ingredientes.Clear();
            _tiposPlato.Clear();
            Nombre = nombre;
            Descripcion = descripcion;
            Foto = foto;
            Porciones = porciones;
            CantidadPersonas = cantidadPersonas;
            AgregarPasos(pasosDTO);
            AgregarTiposPlato(tipoPlatos);
            AgregarIngredientes(ingredientes);
        }

        public void SerPuntuada(Usuario usuario, int puntaje)
        {
            _calificaciones.Add(new Calificacion(usuario, this, puntaje, ""));
        }
    }
}
