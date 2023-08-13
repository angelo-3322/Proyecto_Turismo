using Proyecto_Turismo.Application.Components;
using Proyecto_Turismo.Application.Contracs.Services;
using Proyecto_Turismo.Application.Contracts.Repositories;
using Proyecto_Turismo.Domain.DTOs.Cliente;
using Proyecto_Turismo.Domain.DTOs.Facturas;
using Proyecto_Turismo.Domain.Entities;


namespace Proyecto_Turismo.Application.Services
{
    public class FacturaService : IFacturaService
    {

        private readonly IFacturaRepository _repository;

        public FacturaService(IFacturaRepository repository)
        {
            _repository = repository;
        }

        public EditFactureDTO Get(int id)
        {
            Factura facture = _repository.Get(s => s.Id == id);
            return new EditFactureDTO(facture.Id, facture.FechaEmision, facture.Monto);
        }

        public IEnumerable<ListFactureDTO> GetAll()
        {
            List<Factura> facturas =
                _repository.GetAll
                    (s => s.FechaEmision.Date >= DateTime.Now.Date.AddMonths(-1) || string.IsNullOrEmpty(s.Monto.ToString()),
                    includes: i => i.Reservacion).ToList();

            return facturas.ConvertAll
                (s => new ListFactureDTO(s.Id, s.Reservacion.FechaInicio.ToString(), s.FechaEmision.ToString(), s.Monto));
        }

        public Result<int> Create(CreateFactureDTO dto)
        {
            Factura factura =
                Factura.Create
                (
                    dto.IdReservacion,
                    dto.Monto
                );

            try
            {
                _repository.Instert(factura);
                _repository.Save();
            }
            catch
            {
                return Result.Fail<int>("Internal server error.");
            }

            return Result.Ok<int>(factura.Id);
        }

        public Result Edit(EditFactureDTO dto)
        {
            Factura existingFacture = _repository.GetAll().FirstOrDefault(t => t.Id == dto.Id);

            existingFacture.Update(dto.FechaEmision, dto.Monto);

            _repository.Save();

            return Result.Ok();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
