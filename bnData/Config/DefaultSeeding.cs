using Factory.Models;
using Factory.Enums;
using Factory.Constants;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Transformation;

namespace Data.Config
{
    public static class DefaultSeeding
    {
        public static void startSeeding(Context Context)
        {
            var user = new EntUsers(){
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                IsActive = true,
                //UserCode = 0,
                UserId = "5801F6E0FF954D5A9593507075B930D9",
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                UserName = "System",
                UserKey = StringTransformation.generateHash("system")
            };
            var profile = new EntProfiles(){
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                ProName = "System",
                ProId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var relationProfileUser = new RelUserProfiles(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                UserId = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                ProId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var feature = new EntFeatures(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                FeaId = "5801F6E0FF954D5A9593507075B930D9",
                FeaController = "api/",
                FeaName = "root",
                FeaParent = "5801F6E0FF954D5A9593507075B930D9",
                ShouldShow = false
            };
            var relationProfileFeature = new RelProfilesFeatures(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                FeaId = "5801F6E0FF954D5A9593507075B930D9",
                ProId = "5801F6E0FF954D5A9593507075B930D9",
                Permission = (int)AccessControl.Write
            };
            var contact = new EntContacts(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //ConCode = 0,
                ConId = "5801F6E0FF954D5A9593507075B930D9",
                ConFirstName = "Administrator",
                ConMidleName = "Internal",
                ConLastname = "System",
                ConObservation = "Internal System Administrator",
                IsUser = true
            };
            var relationUserContact = new RelUserContact(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //ConCode = 0,
                ConId = "5801F6E0FF954D5A9593507075B930D9",
                UserId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var phoneNumber = new EntPhoneNumbers()
            {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                PnId = "5801F6E0FF954D5A9593507075B930D9",
                PnType = CommonConstants.PHONE_TYPE_MOBILE_PERSONAL,
                PnName = "Administrator Celphone",
                PnNumber = "+5541999115532"
            };
            var relationPhoneContact = new RelPhoneNumbersContacts()
            {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                PnId = "5801F6E0FF954D5A9593507075B930D9",
                ConId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var contactDetails = new EntContactDetails(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                ConId = "5801F6E0FF954D5A9593507075B930D9",
                CdeId = "5801F6E0FF954D5A9593507075B930D9",
                CdeEmail = "postmaster@bauer.net.br"
            };
            var type1 = new EntTypes(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                TypAllowChange = false,
                //TypCode = 1,
                TypName = "Cash",
                TypId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var type2 = new EntTypes(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                TypAllowChange = false,
                //TypCode = 2,
                TypName = "Savings",
                TypId = "88AFB9D02884458BA2ABDFD36E91738D"
            };
            var type3 = new EntTypes(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                TypAllowChange = false,
                //TypCode = 3,
                TypName = "Deposit",
                TypId = "5C04825380C6476BBE901ADE7C602CF5"
            };
            var type4 = new EntTypes(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                TypAllowChange = false,
                //TypCode = 4,
                TypName = "Article",
                TypId = "FC80F123D1454BF592D8D6AB8FB683F8"
            };
            var type5 = new EntTypes(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                TypAllowChange = false,
                //TypCode = 5,
                TypName = "Bill",
                TypId = "B2B30EE1DD374ACC8FAEFDBA09D67E85"
            };

            var category1 = new EntCategories() {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //CatCode = 1,
                //CatFriendlyCode = "",
                CatName = "Article",
                CatId = "5801F6E0FF954D5A9593507075B930D9",
                TypId = "FC80F123D1454BF592D8D6AB8FB683F8"
            };
            var category2 = new EntCategories() {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //CatCode = 2,
                CatFriendlyCode = "000",
                CatName = "Finnance",
                CatId = "025CA4AC9BFF4022B855E455E24FBEAD",
                TypId = "B2B30EE1DD374ACC8FAEFDBA09D67E85"
            };
            var category3 = new EntCategories() {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //CatCode = 3,
                CatFriendlyCode = "001",
                CatName = "Credit",
                CatId = "DC27C0DE45B54F51B5D3B64DBEDEFAFB",
                TypId = "B2B30EE1DD374ACC8FAEFDBA09D67E85"
            };
            var category4 = new EntCategories() {
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //CatCode = 4,
                CatFriendlyCode = "002",
                CatName = "Debit",
                CatId = "30D5FD05580F4C3BAC545E5EBE616467",
                TypId = "B2B30EE1DD374ACC8FAEFDBA09D67E85"
            };
            var status1 = new EntStatus(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //StaCode = 1,
                StaName = "Realizado",
                StaDescription = "Entrada Financeira se encontra finalizada, integrada e computada.",
                StaId = "5801F6E0FF954D5A9593507075B930D9"
            };
            var status2 = new EntStatus(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //StaCode = 2,
                StaName = "Cancelado",
                StaDescription = "Entrada Financeira se encontra cancelada.",
                StaId = "30D5FD05580F4C3BAC545E5EBE616467"
            };
            var status3 = new EntStatus(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //StaCode = 3,
                StaName = "Ativo",
                StaDescription = "Entrada Financeira se encontra ativa",
                StaId = "B2B30EE1DD374ACC8FAEFDBA09D67E85"
            };
            var status4 = new EntStatus(){
                userIDCreation = "5801F6E0FF954D5A9593507075B930D9",
                userIDLastChange = "5801F6E0FF954D5A9593507075B930D9",
                dtCreation = DateTime.Now,
                dtLastChange = DateTime.Now,
                //StaCode = 4,
                StaName = "Previsto",
                StaDescription = "Entrada Financeira é prevista.",
                StaId = "DC27C0DE45B54F51B5D3B64DBEDEFAFB"
            };
            //Adding entities without references
            Context.EntUsers.Add(user);
            Context.EntProfiles.Add(profile);
            Context.EntFeatures.Add(feature);
            Context.EntContacts.Add(contact);
            Context.EntPhoneNumbers.Add(phoneNumber);
            Context.EntTypes.Add(type1);
            Context.EntTypes.Add(type2);
            Context.EntTypes.Add(type3);
            Context.EntTypes.Add(type4);
            Context.EntTypes.Add(type5);
            Context.EntStatus.Add(status1);
            Context.EntStatus.Add(status2);
            Context.EntStatus.Add(status3);
            Context.EntStatus.Add(status4);
            Context.SaveChanges();
            //Adding entities with fks
            Context.RelUserProfiles.Add(relationProfileUser);
            Context.EntContactDetails.Add(contactDetails);
            Context.RelUserContact.Add(relationUserContact);
            Context.RelPhoneNumbersContacts.Add(relationPhoneContact);
            Context.RelProfilesFeatures.Add(relationProfileFeature);
            Context.EntCategories.Add(category1);
            Context.EntCategories.Add(category2);
            Context.EntCategories.Add(category3);
            Context.EntCategories.Add(category4);
            Context.SaveChanges();
        }
    }
}