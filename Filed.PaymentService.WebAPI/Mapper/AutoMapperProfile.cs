using AutoMapper;
using Field.PaymentService.DataAccess.EntityFramework.Library.Model;
using Filed.PaymentService.WebAPI.Model;
using Filed.PaymentService.WebAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filed.PaymentService.WebAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            try
            {
                CreateMap<Payment, ProcessPaymentResponse>().
                    ForMember(destination => destination.PaymentRefrenceNumber, targetOptions => targetOptions.MapFrom(src => src.Id.GetHashCode().ToString())).
                    ForMember(destination => destination.PaymentAmount, targetOptions => targetOptions.MapFrom(src => $"{ConfigurationConstants.CurrencySymbol} {src.Amount}")).
                    ForMember(destination => destination.PaymentStatus, targetOptions => targetOptions.MapFrom(src => src.Status));
            }
            catch
            {
                throw;
            }
        }
    }
}
