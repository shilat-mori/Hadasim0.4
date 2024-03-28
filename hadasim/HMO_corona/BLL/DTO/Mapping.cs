using AutoMapper;
using DAL.HMO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CoronaVaccine, CoronaVaccine_dto>().
                ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => (src.Id != null) ? src.Id : "0"))//.
                //ForMember(
                //    Vac1 => Vac1.Vac1,
                //    v1 => v1.MapFrom(x => x.Vac1Navigation.Id)).
                //     ForMember(
                //    Vac2 => Vac2.Vac2,
                //    v2 => v2.MapFrom(x => x.Vac2Navigation.Id)).
                //     ForMember(
                //    Vac3 => Vac3.Vac3,
                //    v3 => v3.MapFrom(x => (x.Vac3Navigation.Id))).
                //     ForMember(
                //    Vac4 => Vac4.Vac4,
                //    v4 => v4.MapFrom(x => (x.Vac4Navigation.Id))).
                //    ForMember(
                //    status => status.Status,
                //    dest => dest.MapFrom(x=>(x.Status)))
                            ;
            //if ((src.Vac1 == null || src.Vac1 == 0))
            //{
            //    CreateMap<CoronaVaccine_dto, CoronaVaccine>()
            //    .ForMember(
            //        dest => dest.Id,
            //        opt => opt.MapFrom(src => (src.Id != null) ? src.Id : "(object)null"))
            //    .ForMember(
            //        dest => dest.Vac1Navigation,
            //        opt => opt.MapFrom(src => (Vaccine?)null))
            //    .ForMember(
            //        dest => dest.Vac2Navigation,
            //        opt => opt.MapFrom(src => new Vaccine { Id = src.Vac2 }))
            //    .ForMember(
            //        dest => dest.Vac3Navigation,
            //        opt => opt.MapFrom(src => new Vaccine { Id = src.Vac3 }))
            //    .ForMember(
            //        dest => dest.Vac4Navigation,
            //        opt => opt.MapFrom(src => new Vaccine { Id = src.Vac4 }));
           // }
           // else
           // {
                CreateMap<CoronaVaccine_dto, CoronaVaccine>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => (src.Id != null) ? src.Id : "(object)null"))
                .ForMember(
                    dest => dest.Vac1Navigation,
                    opt => opt.MapFrom(src => (src.Vac1.GetValueOrDefault() >= 0) ? new Vaccine { Id = src.Vac1.GetValueOrDefault() } : null))
                .ForMember(
                    dest => dest.Vac2Navigation,
                    opt => opt.MapFrom(src => (src.Vac2.GetValueOrDefault() >= 0) ? new Vaccine { Id = src.Vac2.GetValueOrDefault() } : null))
                .ForMember(
                    dest => dest.Vac3Navigation,
                    opt => opt.MapFrom(src => (src.Vac3.GetValueOrDefault() >= 0) ? new Vaccine { Id = src.Vac3.GetValueOrDefault() } : null))
                .ForMember(
                    dest => dest.Vac4Navigation,
                    opt => opt.MapFrom(src => (src.Vac4.GetValueOrDefault() >= 0) ? new Vaccine { Id = src.Vac4.GetValueOrDefault() } : null));
            //}


            CreateMap<Patient, Patient_dto>();
            CreateMap<Patient_dto, Patient>().
                ForMember(
                    dest => dest.Address,
                    opt => opt.MapFrom(src => (src.AddressId.GetValueOrDefault() > 0)? new PatientAddress { Id = src.AddressId.GetValueOrDefault() }:null)
                );

            CreateMap<PatientAddress, PatientAddress_dto>();
            CreateMap<PatientAddress_dto, PatientAddress>();

            CreateMap<Producer, Producter_dto>();
            CreateMap<Producter_dto, Producer>();

            CreateMap<Serologion, Serologion_dto>();
            CreateMap<Serologion_dto, Serologion>();

            CreateMap<Vaccine, Vaccine_dto>();
            CreateMap<Vaccine_dto, Vaccine>();

        }
    }
}
