﻿using AutoMapper;
using PSW_ClinicSystem.Data;
using PSW_ClinicSystem.DTO;
using PSW_ClinicSystem.Interfaces;
using PSW_ClinicSystem.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_ClinicSystem.Services
{
    public class ReferralService : IReferralService
    {
        private IReferralRepository referralRepository;
        private IMapper mapper; // mapping Db entities to DTOs

        public ReferralService(IReferralRepository repository, IMapper maper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(referralRepository), "Repository cannot be null");
            }
            referralRepository = repository;
            mapper = maper;
        }


        public void CreateReferral(ReferralDTO referral)
        {
            var referralEntity = mapper.Map<Referral>(referral);
            referralRepository.Add(referralEntity);
            referralRepository.Save();
        }

        public void DeleteReferral(int referralId)
        {

            var referral = referralRepository.GetById(referralId);

            referralRepository.Remove(referral);
            referralRepository.Save();
        }


        public ReferralResponseDTO GetById(int referralId)
        {
            var referral = referralRepository.GetById(referralId);

            return mapper.Map<ReferralResponseDTO>(referral);
        }

        public IEnumerable<ReferralResponseDTO> GetReferrals()
        {
            var referrals = referralRepository.GetAll();
            return mapper.Map<IEnumerable<ReferralResponseDTO>>(referrals);
        }

    }
}
