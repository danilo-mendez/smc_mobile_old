using System;
using System.Collections.Generic;
using System.Text;

namespace Smc.Mobile.Model
{

    public class ClientModel
    {

        public ClientModel()
        {

            EthnicityHispanicLatino = 1;
            AmericanIndianAlaskaNative = 0;
            Asian = 0;
            BlackAfricanAmerican = 0;
            NativeHawaiianOtherPacificIslander = 0;
            White = 0;
            IndividualwithaDisability = 0;
        }


        public int ClientId { get; set; }
        public string UniqueIndividualIdentifier { get; set; }
        public string ClientSSN { get; set; }
        public string FileNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public System.DateTime? DateofBirth { get; set; }
        public System.DateTime? DateVerifySelectiveServiceRegistration { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<int> EthnicityHispanicLatino { get; set; }
        public Nullable<int> AmericanIndianAlaskaNative { get; set; }
        public Nullable<int> Asian { get; set; }
        public Nullable<int> BlackAfricanAmerican { get; set; }
        public Nullable<int> NativeHawaiianOtherPacificIslander { get; set; }
        public Nullable<int> White { get; set; }
        public Nullable<int> IndividualwithaDisability { get; set; }
        public Nullable<int> CategoryOfDisability { get; set; }
        public int[] CategoriesOfDisability { get; set; }
        public string PhysicalAddress1 { get; set; }
        public string PhysicalAddress2 { get; set; }
        public string PhysicalAddressZipCode { get; set; }
        public string PhysicalAddressZipCodeExtension { get; set; }
        public string PhysicalAddressCity { get; set; }
        public string PhysicalAddressState { get; set; }
        public string PhysicalAddressCountry { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalAddressZipCode { get; set; }
        public string PostalAddressZipCodeExtension { get; set; }
        public string PostalAddressCity { get; set; }
        public string PostalAddressState { get; set; }
        public string PostalAddressCountry { get; set; }
        public string Telephone1 { get; set; }
        public Nullable<int> TelephoneType1 { get; set; }
        public string Telephone2 { get; set; }
        public Nullable<int> TelephoneType2 { get; set; }
        public string Telephone3 { get; set; }
        public Nullable<int> TelephoneType3 { get; set; }
        public string Email { get; set; }
        public string EmailAlternate { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string ContactName { get; set; }
        public Nullable<int> ContactRelationship { get; set; }
        public string ContactPhysicalAddress1 { get; set; }
        public string ContactPhysicalAddress2 { get; set; }
        public string ContactPhysicalAddressZipCode { get; set; }
        public string ContactPhysicalAddressZipCodeExtension { get; set; }
        public string ContactPhysicalAddressCity { get; set; }
        public string ContactPhysicalAddressState { get; set; }
        public string ContactPhysicalAddressCountry { get; set; }
        public String ContactTelephone1 { get; set; }
        public Nullable<int> ContactTelephoneType1 { get; set; }
        public String ContactTelephone2 { get; set; }
        public Nullable<int> ContactTelephoneType2 { get; set; }
        public string ContactEmail { get; set; }
        public Nullable<int> PreferredContact { get; set; }
        public Nullable<int> PreferredContactAlternate { get; set; }
        public Nullable<int> DriverLicense { get; set; }
        public Nullable<int> DriverLicenseCategory { get; set; }
        public Nullable<int> HighestEducationalLevelCompleted { get; set; }
        public string HighestEducationalLevelCompletedDescription { get; set; }
        public Nullable<int> PreferredLaborArea1 { get; set; }
        public string PreferredLaborArea1Description { get; set; }
        public string PreferredLaborArea1Desc { get; set; }
        public Nullable<int> PreferredLaborArea2 { get; set; }
        public string PreferredLaborArea2Desc { get; set; }
        public string PreferredLaborArea2Description { get; set; }
        public Nullable<int> Citizen { get; set; }
        public Nullable<int> SelectiveService { get; set; }


    }
}