﻿namespace recipes_backend.Dtos.Receta
{
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Models.Domain;

    public class RecetaInfoDTO
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Descripcion { get; set; }
        public List<CategoriaDTO> Categorias { get; set; } = new List<CategoriaDTO>();
        public List<ViewIngredienteDTO> Ingredientes { get; set; } = new List<ViewIngredienteDTO>();
        public List<PasoDTO> Pasos { get; set; } = new List<PasoDTO>();
        public double Calificacion { get; set; }
        public int Porciones { get; set; }

        public RecetaInfoDTO(Receta recipe)
        {
            Id = recipe.Id;
            Imagen = recipe.Foto;
            Nombre = recipe.Nombre;
            NombreUsuario = recipe.Usuario.NickName;
            Descripcion = recipe.Descripcion;
            recipe.TiposPlato.ToList().ForEach(tp => Categorias.Add(new CategoriaDTO(tp.TipoPlato)));
            Calificacion = recipe.Calificaciones.Count == 0 ? 0.0 : recipe.Calificaciones.Average(r => r.Puntaje);
            Porciones = recipe.Porciones;
            recipe.Ingredientes.ToList().ForEach(i => Ingredientes.Add(new ViewIngredienteDTO {
                Nombre = i.Ingrediente.Nombre,
                Cantidad = i.Cantidad.ToString(),
                Unidad = i.Unidad.Id,
                Descripcion = i.Observaciones
            }));
            recipe.Pasos.ToList().ForEach(p => Pasos.Add(new PasoDTO {
                Number = p.NroPaso,
                Titulo = p.Titulo,
                Descripcion = p.Texto,
                Media = p.Multimedias.Select(m => m.UrlContenido).ToList()
            }));
        }
    }
}
