using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Repositories;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Domain.DTOs.Imagen;
using Proyecto_Turismo.Domain.Entities;

namespace Proyecto_Turismo.Application.Services
{
    public class ImagenService : IImagenService
    {
        private readonly IImagenRepository _repository;

        public ImagenService(IImagenRepository repository) 
        {
            _repository = repository;
        }
        public Result<int> Create(CreateImagenDTO dto)
        {
            var imagen = new Imagen
            {
                DatosImagen = dto.DatosImagen
            };

            try
            {
                _repository.Instert(imagen);
                _repository.Save();

                return Result.Ok<int>(imagen.Id);
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }
        }

        public Result Delete(int id)
        {
            var imagen = _repository.Get(i => i.Id == id);
            if (imagen == null)
            {
                return Result.Fail("Image not found");
            }

            try
            {
                _repository.Delete(imagen);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public Result Edit(EditImagenDTO dto)
        {
            var imagen = _repository.Get(i => i.Id == dto.Id);
            if (imagen == null)
            {
                return Result.Fail("Image not found");
            }

            imagen.DatosImagen = dto.DatosImagen;

            try
            {
                _repository.Update(imagen);
                _repository.Save();

                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Internal server error.");
            }
        }

        public EditImagenDTO Get(int id)
        {
           Imagen imagen = _repository.Get(s => s.Id == id);
           return new EditImagenDTO(imagen.Id,imagen.DatosImagen);
        }

        public IEnumerable<ListImagenDTO> GetAll()
        {
            var imagenes = _repository.GetAll().ToList();

            return imagenes.ConvertAll(i => new ListImagenDTO(i.Id,i.DatosImagen,i.IdHabitacion));
        }
    }
}
