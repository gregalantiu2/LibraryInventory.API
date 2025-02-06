using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Model.TransactionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Service.MapperProfiles
{
    public class TransactionMapperProfile : Profile
    {
        public TransactionMapperProfile()
        {
            CreateMap<TransactionPaymentTypeEntity, TransactionPaymentType>()
                .ForCtorParam("transactionPaymentTypeId", opt => opt.MapFrom(src => src.TransactionPaymentTypeId))
                .ForCtorParam("transactionPaymentTypeName", opt => opt.MapFrom(src => src.TransactionPaymentTypeName));

            CreateMap<TransactionPaymentType, TransactionPaymentTypeEntity>()
                .ForMember(dest => dest.TransactionPaymentTypeId, opt => opt.MapFrom(src => src.TransactionPaymentTypeId))
                .ForMember(dest => dest.TransactionPaymentTypeName, opt => opt.MapFrom(src => src.TransactionPaymentTypeName));

            CreateMap<TransactionPayment, TransactionPaymentEntity>()
                .ForMember(dest => dest.PaymentAmount, opt => opt.MapFrom(src => src.PaymentAmount))
                .ForMember(dest => dest.TransactionPaymentTypeId, opt => opt.MapFrom(src => src.TransactionPaymentType.TransactionPaymentTypeId));

            CreateMap<TransactionTypeEntity, TransactionType>()
                .ForCtorParam("transactionTypeId", opt => opt.MapFrom(src => src.TransactionTypeId))
                .ForCtorParam("transactionTypeName", opt => opt.MapFrom(src => src.TransactionTypeName));

            CreateMap<TransactionType, TransactionTypeEntity>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionTypeId))
                .ForMember(dest => dest.TransactionTypeName, opt => opt.MapFrom(src => src.TransactionTypeName));

            CreateMap<TransactionEntity, Transaction>()
                .ForCtorParam("transactionId", opt => opt.MapFrom(src => src.TransactionId))
                .ForCtorParam("transactionDate", opt => opt.MapFrom(src => src.TransactionDate))
                .ForCtorParam("transactionType", opt => opt.MapFrom(src => src.TransactionType))
                .ForCtorParam("transactionPayments", opt => opt.MapFrom(src => src.TransactionPayments))
                .ForCtorParam("memberId", opt => opt.MapFrom(src => src.MemberId))
                .ForCtorParam("itemId", opt => opt.MapFrom(src => src.ItemId));

            CreateMap<Transaction, TransactionEntity>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionType))
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionType.TransactionTypeId))
                .ForMember(dest => dest.TransactionPayments, opt => opt.MapFrom(src => src.TransactionPayments))
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.MemberId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId));
        }
    }
}
