using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Resources;
using System.Windows.Forms;

namespace Library
{
    public class ItemConstant
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public int ID { set; get; }
        public string Sku { set; get; }
        public decimal ExtraValue { get; set; }
        public int NumberPepole { get; set; }
        public int CustomerType { set; get; }
        public string PriceType { set; get; }
    }
    public class ItemEmail
    {

        public string ID { set; get; }
        public string PassWord { set; get; }
    }
    public class EmailInfomation
    {

        public ItemEmail SenderMail = new ItemEmail();
        public ItemEmail ReceiverMail1 = new ItemEmail();
        public ItemEmail ReceiverMail2 = new ItemEmail();
    }
    public class ConstantsXML
    {
        public EmailInfomation ListEmails = new EmailInfomation();
        public List<ItemConstant> ListCountries = new List<ItemConstant>();
        public List<ItemConstant> ListGenders = new List<ItemConstant>();
        public List<ItemConstant> ListRoomsTypes = new List<ItemConstant>();
        public List<ItemConstant> ListCitizens = new List<ItemConstant>();

        public List<ItemConstant> ListCustomerTypes = new List<ItemConstant>();
        public List<ItemConstant> ListLevels = new List<ItemConstant>();
        public List<ItemConstant> ListPayMethods = new List<ItemConstant>();
        public List<ItemConstant> ListStatusPays = new List<ItemConstant>();

        public List<ItemConstant> ListBookingRoomStatus = new List<ItemConstant>();
        public List<ItemConstant> ListBookingRStatus = new List<ItemConstant>();
        public List<ItemConstant> ListCustomerStatus = new List<ItemConstant>();
        public List<ItemConstant> ListContractTypes = new List<ItemConstant>();
        public List<ItemConstant> ListAllowancesTypes = new List<ItemConstant>();
        public List<ItemConstant> ListSalaryTypes = new List<ItemConstant>();
        public List<ItemConstant> ListCertificatesTypes = new List<ItemConstant>();
        public List<ItemConstant> ListTrainingTypes = new List<ItemConstant>();
        public List<ItemConstant> ListRelationTypes = new List<ItemConstant>();

        public List<ItemConstant> ListDocumentSystemUsersTypes = new List<ItemConstant>();
        public List<ItemConstant> ListOrganizations = new List<ItemConstant>();
        public List<ItemConstant> ListSystemUsers_Certificates_Levels = new List<ItemConstant>();
        public List<ItemConstant> ListServiceTypes = new List<ItemConstant>();

        public List<ItemConstant> ListHallTypes = new List<ItemConstant>();
        public List<ItemConstant> ListBookingHallStatus = new List<ItemConstant>();
        public List<ItemConstant> ListBookingHStatus = new List<ItemConstant>();
        public List<ItemConstant> ListBookingTypes = new List<ItemConstant>();
       
        //public List<ItemConstant> ListExtraCost = new List<ItemConstant>();






        public void LoadAllConstant()
        {
            this.LoadCountries();
            this.LoadGenders();
            this.LoadRoomsType();
            this.LoadCitizen();
            this.LoadCertificateTypes();

            this.LoadCustomerType();
            this.LoadLevel();
            this.LoadPayMethod();
            this.LoadStatusPay();

            this.LoadBookingRoomStatus();
            this.LoadBookingRStatus();
            this.LoadCustomerStatus();
            this.LoadContractTypes();

          
            this.LoadSalaryType();
            this.LoadCertificateTypes();
            this.LoadTrainingTypes();
            this.LoadRelationType();

            this.LoadDocumentSystemUsersType();
            this.LoadOrganizations();
            this.LoadSystemUsers_Certificates_Levels();
            this.LoadServiceType();
            //this.LoadExtraCost();
            this.LoadEmails();
            this.LoadHallType();
            this.LoadBookingType();
            this.LoadHallType();
            this.LoadBookingHallStatus();
            this.LoadBookingHStatus();
        }

        private EmailInfomation LoadEmails()
        {
            this.ListEmails = new EmailInfomation();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Email);
            XmlNode SenderMail = doc.SelectNodes("//SenderMail")[0];
            XmlNode ReceiverMail1 = doc.SelectNodes("//ReceiverMail")[0];
            XmlNode ReceiverMail2 = doc.SelectNodes("//ReceiverMail")[1];
            this.ListEmails.SenderMail.ID = SenderMail.Attributes["ID"].Value;
            this.ListEmails.SenderMail.PassWord = SenderMail.Attributes["Password"].Value;
            this.ListEmails.ReceiverMail1.ID = ReceiverMail1.Attributes["ID"].InnerText;
            this.ListEmails.ReceiverMail2.ID = ReceiverMail2.Attributes["ID"].InnerText;
            return this.ListEmails;
        }





        //================================================================
        private List<ItemConstant> LoadCountries()
        {

            this.ListCountries = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.countries);
            ItemConstant aCountry = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//country"))
            {
                aCountry = new ItemConstant();
                aCountry.Code = node.Attributes["Code"].InnerText;
                aCountry.ID = int.Parse(node.Attributes["ID"].InnerText);
                aCountry.Name = node.InnerText;
                this.ListCountries.Add(aCountry);
            }
            return this.ListCountries;
        }
        public ItemConstant SelectedCountry(int ID)
        {

            ItemConstant aCountry = new ItemConstant();
            foreach (var node in this.ListCountries)
            {
                if (node.ID == ID)
                {
                    aCountry = new ItemConstant();
                    aCountry.Code = node.Code;
                    aCountry.ID = node.ID;
                    aCountry.Name = node.Name;
                    return aCountry;

                }

            }

            return aCountry;
        }
        public ItemConstant SelectedCountry(string Code)
        {

            ItemConstant aCountry = new ItemConstant();
            foreach (var node in this.ListCountries)
            {
                if (node.Code == Code.ToString())
                {
                    aCountry = new ItemConstant();
                    aCountry.Code = node.Code;
                    aCountry.ID = node.ID;
                    aCountry.Name = node.Name;
                    return aCountry;

                }

            }

            return aCountry;
        }
        //================================================================
        private List<ItemConstant> LoadGenders()
        {
            this.ListGenders = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Genders);
            ItemConstant aGender = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//Gender"))
            {
                aGender = new ItemConstant();
                aGender.Code = node.Attributes["Code"].InnerText;
                aGender.ID = int.Parse(node.Attributes["ID"].InnerText);
                aGender.Name = node.InnerText;
                this.ListGenders.Add(aGender);
            }
            return this.ListGenders;
        }
        public ItemConstant SelectedGender(int ID)
        {

            ItemConstant aGender = new ItemConstant();
            foreach (var node in ListGenders)
            {
                if (node.ID == ID)
                {
                    aGender = new ItemConstant();
                    aGender.Code = node.Code;
                    aGender.ID = node.ID;
                    aGender.Name = node.Name;
                    return aGender;

                }

            }

            return aGender;
        }
        public ItemConstant SelectedGender(string Code)
        {

            ItemConstant aGender = new ItemConstant();
            foreach (var node in ListGenders)
            {
                if (node.Code == Code.ToString())
                {
                    aGender = new ItemConstant();
                    aGender.Code = node.Code;
                    aGender.ID = node.ID;
                    aGender.Name = node.Name;
                    return aGender;

                }

            }

            return aGender;
        }
        //================================================================
        private List<ItemConstant> LoadRoomsType()
        {
            ListRoomsTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.RoomTypes);

            ItemConstant aRoomsType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//RoomType"))
            {
                aRoomsType = new ItemConstant();
                aRoomsType.Code = node.Attributes["Code"].InnerText;
                aRoomsType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aRoomsType.Name = node.InnerText;
                ListRoomsTypes.Add(aRoomsType);
            }
            return ListRoomsTypes;
        }
        public ItemConstant SelectedRoomsType(int ID)
        {

            ItemConstant aRoomsType = new ItemConstant();
            foreach (var node in ListRoomsTypes)
            {
                if (node.ID == ID)
                {
                    aRoomsType = new ItemConstant();
                    aRoomsType.Code = node.Code;
                    aRoomsType.ID = node.ID;
                    aRoomsType.Name = node.Name;
                    return aRoomsType;

                }

            }

            return aRoomsType;
        }
        public ItemConstant SelectedRoomsType(string Code)
        {

            ItemConstant aRoomsType = new ItemConstant();
            foreach (var node in ListRoomsTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aRoomsType = new ItemConstant();
                    aRoomsType.Code = node.Code;
                    aRoomsType.ID = node.ID;
                    aRoomsType.Name = node.Name;
                    return aRoomsType;

                }

            }

            return aRoomsType;
        }
        //================================================================
        private List<ItemConstant> LoadContractTypes()
        {
            ListContractTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.ContractTypes);
            ItemConstant aContract = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//ContractType"))
            {
                aContract = new ItemConstant();
                aContract.Code = node.Attributes["Code"].InnerText;
                aContract.ID = int.Parse(node.Attributes["ID"].InnerText);
                aContract.Name = node.InnerText;
                ListContractTypes.Add(aContract);
            }
            return ListContractTypes;
        }
        public ItemConstant SelectedContractType(int ID)
        {

            ItemConstant aContractType = new ItemConstant();
            foreach (var node in ListContractTypes)
            {
                if (node.ID == ID)
                {
                    aContractType = new ItemConstant();
                    aContractType.Code = node.Code;
                    aContractType.ID = node.ID;
                    aContractType.Name = node.Name;
                    return aContractType;

                }

            }

            return aContractType;
        }
        public ItemConstant SelectedContractType(string Code)
        {

            ItemConstant aContractType = new ItemConstant();
            foreach (var node in ListContractTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aContractType = new ItemConstant();
                    aContractType.Code = node.Code;
                    aContractType.ID = node.ID;
                    aContractType.Name = node.Name;
                    return aContractType;

                }

            }

            return aContractType;
        }
        //================================================================
        private List<ItemConstant> LoadTrainingTypes()
        {
            ListTrainingTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.TrainingTypes);
            ItemConstant aTraining = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//TrainingType"))
            {
                aTraining = new ItemConstant();
                aTraining.Code = node.Attributes["Code"].InnerText;
                aTraining.ID = int.Parse(node.Attributes["ID"].InnerText);
                aTraining.Name = node.InnerText;
                ListTrainingTypes.Add(aTraining);
            }
            return ListTrainingTypes;
        }
        public ItemConstant SelectedTrainingType(int ID)
        {

            ItemConstant aTrainingType = new ItemConstant();
            foreach (var node in ListTrainingTypes)
            {
                if (node.ID == ID)
                {
                    aTrainingType = new ItemConstant();
                    aTrainingType.Code = node.Code;
                    aTrainingType.ID = node.ID;
                    aTrainingType.Name = node.Name;
                    return aTrainingType;

                }

            }

            return aTrainingType;
        }
        public ItemConstant SelectedTrainingType(string Code)
        {

            ItemConstant aTrainingType = new ItemConstant();
            foreach (var node in ListTrainingTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aTrainingType = new ItemConstant();
                    aTrainingType.Code = node.Code;
                    aTrainingType.ID = node.ID;
                    aTrainingType.Name = node.Name;
                    return aTrainingType;

                }

            }

            return aTrainingType;
        }
        //================================================================
        private List<ItemConstant> LoadCertificateTypes()
        {
            ListCertificatesTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.CertificatesTypes);
            ItemConstant aCertificate = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//CertificateType"))
            {
                aCertificate = new ItemConstant();
                aCertificate.Code = node.Attributes["Code"].InnerText;
                aCertificate.ID = int.Parse(node.Attributes["ID"].InnerText);
                aCertificate.Name = node.InnerText;
                ListCertificatesTypes.Add(aCertificate);
            }
            return ListCertificatesTypes;
        }
        public ItemConstant SelectedCertificateTypes(int ID)
        {

            ItemConstant aCertificateType = new ItemConstant();
            foreach (var node in ListCertificatesTypes)
            {
                if (node.ID == ID)
                {
                    aCertificateType = new ItemConstant();
                    aCertificateType.Code = node.Code;
                    aCertificateType.ID = node.ID;
                    aCertificateType.Name = node.Name;
                    return aCertificateType;

                }

            }

            return aCertificateType;
        }
        public ItemConstant SelectedCertificateTypes(string Code)
        {

            ItemConstant aCertificateType = new ItemConstant();
            foreach (var node in ListCertificatesTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aCertificateType = new ItemConstant();
                    aCertificateType.Code = node.Code;
                    aCertificateType.ID = node.ID;
                    aCertificateType.Name = node.Name;
                    return aCertificateType;

                }

            }

            return aCertificateType;
        }
        //================================================================
        private List<ItemConstant> LoadCitizen()
        {
            ListCitizens = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Citizens);
            ItemConstant aCitizen = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//Citizen"))
            {
                aCitizen = new ItemConstant();
                aCitizen.Code = node.Attributes["Code"].InnerText;
                aCitizen.ID = int.Parse(node.Attributes["ID"].InnerText);
                aCitizen.Name = node.InnerText;
                ListCitizens.Add(aCitizen);
            }
            return ListCitizens;
        }
        public ItemConstant SelectedCitizen(int ID)
        {

            ItemConstant aCitizen = new ItemConstant();
            foreach (var node in ListCitizens)
            {
                if (node.ID == ID)
                {
                    aCitizen = new ItemConstant();
                    aCitizen.Code = node.Code;
                    aCitizen.ID = node.ID;
                    aCitizen.Name = node.Name;
                    return aCitizen;

                }

            }

            return aCitizen;
        }
        public ItemConstant SelectedCitizen(string Code)
        {

            ItemConstant aCitizen = new ItemConstant();
            foreach (var node in ListCitizens)
            {
                if (node.Code == Code.ToString())
                {
                    aCitizen = new ItemConstant();
                    aCitizen.Code = node.Code;
                    aCitizen.ID = node.ID;
                    aCitizen.Name = node.Name;
                    return aCitizen;

                }

            }

            return aCitizen;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadCustomerType()
        {
            ListCustomerTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.CustomerTypes);
            ItemConstant aCustomerType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//CustomerType"))
            {
                aCustomerType = new ItemConstant();
                aCustomerType.Code = node.Attributes["Code"].InnerText;
                aCustomerType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aCustomerType.Name = node.InnerText;
                ListCustomerTypes.Add(aCustomerType);
            }
            return ListCustomerTypes;
        }
        public ItemConstant SelectedCustomerType(int ID)
        {

            ItemConstant aCustomerType = new ItemConstant();
            foreach (var node in ListCustomerTypes)
            {
                if (node.ID == ID)
                {
                    aCustomerType = new ItemConstant();
                    aCustomerType.Code = node.Code;
                    aCustomerType.ID = node.ID;
                    aCustomerType.Name = node.Name;
                    return aCustomerType;
                }

            }

            return aCustomerType;
        }
        public ItemConstant SelectedCustomerType(string Code)
        {

            ItemConstant aCustomerType = new ItemConstant();
            foreach (var node in ListCustomerTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aCustomerType = new ItemConstant();
                    aCustomerType.Code = node.Code;
                    aCustomerType.ID = node.ID;
                    aCustomerType.Name = node.Name;
                    return aCustomerType;

                }

            }

            return aCustomerType;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadLevel()
        {
            ListLevels = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Levels);
            ItemConstant aLevel = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//Level"))
            {
                aLevel = new ItemConstant();
                aLevel.Code = node.Attributes["Code"].InnerText;
                aLevel.ID = int.Parse(node.Attributes["ID"].InnerText);
                aLevel.Name = node.InnerText;
                ListLevels.Add(aLevel);
            }
            return ListLevels;
        }
        public ItemConstant SelectedLevel(int ID)
        {

            ItemConstant aLevel = new ItemConstant();
            foreach (var node in ListLevels)
            {
                if (node.ID == ID)
                {
                    aLevel = new ItemConstant();
                    aLevel.Code = node.Code;
                    aLevel.ID = node.ID;
                    aLevel.Name = node.Name;
                    return aLevel;

                }

            }

            return aLevel;
        }
        public ItemConstant SelectedLevel(string Code)
        {

            ItemConstant aLevel = new ItemConstant();
            foreach (var node in ListLevels)
            {
                if (node.Code == Code.ToString())
                {
                    aLevel = new ItemConstant();
                    aLevel.Code = node.Code;
                    aLevel.ID = node.ID;
                    aLevel.Name = node.Name;
                    return aLevel;

                }

            }

            return aLevel;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadPayMethod()
        {
            ListPayMethods = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.PayMethods);
            ItemConstant aPayMethod = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//PayMethod"))
            {
                aPayMethod = new ItemConstant();
                aPayMethod.Code = node.Attributes["Code"].InnerText;
                aPayMethod.ID = int.Parse(node.Attributes["ID"].InnerText);
                aPayMethod.Name = node.InnerText;
                ListPayMethods.Add(aPayMethod);
            }
            return ListPayMethods;
        }
        public ItemConstant SelectedPayMethod(int ID)
        {

            ItemConstant aPayMethod = new ItemConstant();
            foreach (var node in ListPayMethods)
            {
                if (node.ID == ID)
                {
                    aPayMethod = new ItemConstant();
                    aPayMethod.Code = node.Code;
                    aPayMethod.ID = node.ID;
                    aPayMethod.Name = node.Name;
                    return aPayMethod;

                }

            }

            return aPayMethod;
        }
        public ItemConstant SelectedPayMethod(string Code)
        {

            ItemConstant aPayMethod = new ItemConstant();
            foreach (var node in ListPayMethods)
            {
                if (node.Code == Code.ToString())
                {
                    aPayMethod = new ItemConstant();
                    aPayMethod.Code = node.Code;
                    aPayMethod.ID = node.ID;
                    aPayMethod.Name = node.Name;
                    return aPayMethod;

                }

            }

            return aPayMethod;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadStatusPay()
        {
            ListStatusPays = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aStatusPay = new ItemConstant();


            foreach (XmlNode node in doc.SelectNodes("/ListStatus/StatusPays/Status"))
            {
                aStatusPay = new ItemConstant();
                aStatusPay.Code = node.Attributes["Code"].InnerText;
                aStatusPay.ID = int.Parse(node.Attributes["ID"].InnerText);
                aStatusPay.Name = node.InnerText;
                ListStatusPays.Add(aStatusPay);
            }
            return ListStatusPays;
        }
        public ItemConstant SelectedStatusPay(int ID)
        {

            ItemConstant aStatusPay = new ItemConstant();
            foreach (var node in ListStatusPays)
            {
                if (node.ID == ID)
                {
                    aStatusPay = new ItemConstant();
                    aStatusPay.Code = node.Code;
                    aStatusPay.ID = node.ID;
                    aStatusPay.Name = node.Name;
                    return aStatusPay;

                }

            }

            return aStatusPay;
        }
        public ItemConstant SelectedStatusPay(string Code)
        {

            ItemConstant aStatusPay = new ItemConstant();
            foreach (var node in ListStatusPays)
            {
                if (node.Code == Code.ToString())
                {
                    aStatusPay = new ItemConstant();
                    aStatusPay.Code = node.Code;
                    aStatusPay.ID = node.ID;
                    aStatusPay.Name = node.Name;
                    return aStatusPay;

                }

            }

            return aStatusPay;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadBookingRoomStatus()
        {
            ListBookingRoomStatus = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aBookingRoomStatus = new ItemConstant();


            foreach (XmlNode node in doc.SelectNodes("/ListStatus/BookingRoomStatus/Status"))
            {
                aBookingRoomStatus = new ItemConstant();
                aBookingRoomStatus.Code = node.Attributes["Code"].InnerText;
                aBookingRoomStatus.ID = int.Parse(node.Attributes["ID"].InnerText);
                aBookingRoomStatus.Name = node.InnerText;
                ListBookingRoomStatus.Add(aBookingRoomStatus);
            }
            return ListBookingRoomStatus;
        }
        public ItemConstant SelectedBookingRoomStatus(int ID)
        {

            ItemConstant aBookingRoomStatus = new ItemConstant();
            foreach (var node in ListBookingRoomStatus)
            {
                if (node.ID == ID)
                {
                    aBookingRoomStatus = new ItemConstant();
                    aBookingRoomStatus.Code = node.Code;
                    aBookingRoomStatus.ID = node.ID;
                    aBookingRoomStatus.Name = node.Name;
                    return aBookingRoomStatus;

                }

            }

            return aBookingRoomStatus;
        }
        public ItemConstant SelectedBookingRoomStatus(string Code)
        {

            ItemConstant aBookingRoomStatus = new ItemConstant();
            foreach (var node in ListBookingRoomStatus)
            {
                if (node.Code == Code.ToString())
                {
                    aBookingRoomStatus = new ItemConstant();
                    aBookingRoomStatus.Code = node.Code;
                    aBookingRoomStatus.ID = node.ID;
                    aBookingRoomStatus.Name = node.Name;
                    return aBookingRoomStatus;

                }

            }

            return aBookingRoomStatus;
        }
        //================================================================
        //================================================================
        private List<ItemConstant> LoadBookingRStatus()
        {
            ListBookingRStatus = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aBookingRStatus = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListStatus/BookingRStatus/Status"))
            {
                aBookingRStatus = new ItemConstant();
                aBookingRStatus.Code = node.Attributes["Code"].InnerText;
                aBookingRStatus.ID = int.Parse(node.Attributes["ID"].InnerText);
                aBookingRStatus.Name = node.InnerText;
                ListBookingRStatus.Add(aBookingRStatus);
            }
            return ListBookingRStatus;
        }
        public ItemConstant SelectedBookingRStatus(int ID)
        {

            ItemConstant aBookingRStatus = new ItemConstant();
            foreach (var node in ListBookingRStatus)
            {
                if (node.ID == ID)
                {
                    aBookingRStatus = new ItemConstant();
                    aBookingRStatus.Code = node.Code;
                    aBookingRStatus.ID = node.ID;
                    aBookingRStatus.Name = node.Name;
                    return aBookingRStatus;

                }

            }

            return aBookingRStatus;
        }
        public ItemConstant SelectedBookingRStatus(string Code)
        {

            ItemConstant aBookingRStatus = new ItemConstant();
            foreach (var node in ListBookingRStatus)
            {
                if (node.Code == Code.ToString())
                {
                    aBookingRStatus = new ItemConstant();
                    aBookingRStatus.Code = node.Code;
                    aBookingRStatus.ID = node.ID;
                    aBookingRStatus.Name = node.Name;
                    return aBookingRStatus;

                }

            }

            return aBookingRStatus;
        }
        //================================================================
        //================================================================
        public List<ItemConstant> LoadCustomerStatus()
        {
            ListCustomerStatus = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aCustomerStatus = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListStatus/CustomerStatus/Status"))
            {
                aCustomerStatus = new ItemConstant();
                aCustomerStatus.Code = node.Attributes["Code"].InnerText;
                aCustomerStatus.ID = int.Parse(node.Attributes["ID"].InnerText);
                aCustomerStatus.Name = node.InnerText;
                ListCustomerStatus.Add(aCustomerStatus);
            }
            return ListCustomerStatus;
        }
        public ItemConstant SelectedCustomerStatus(int ID)
        {

            ItemConstant aCustomerStatus = new ItemConstant();
            foreach (var node in ListCustomerStatus)
            {
                if (node.ID == ID)
                {
                    aCustomerStatus = new ItemConstant();
                    aCustomerStatus.Code = node.Code;
                    aCustomerStatus.ID = node.ID;
                    aCustomerStatus.Name = node.Name;
                    return aCustomerStatus;

                }

            }

            return aCustomerStatus;
        }
        public ItemConstant SelectedCustomerStatus(string Code)
        {

            ItemConstant aCustomerStatus = new ItemConstant();
            foreach (var node in ListCustomerStatus)
            {
                if (node.Code == Code.ToString())
                {
                    aCustomerStatus = new ItemConstant();
                    aCustomerStatus.Code = node.Code;
                    aCustomerStatus.ID = node.ID;
                    aCustomerStatus.Name = node.Name;
                    return aCustomerStatus;

                }

            }

            return aCustomerStatus;
        }

        //================================================================
        //================================================================
        public List<ItemConstant> LoadAllowancesType()
        {
            ListAllowancesTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Type);
            ItemConstant aAllowancesType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListType/AllowancesType/Type"))
            {
                aAllowancesType = new ItemConstant();
                aAllowancesType.Code = node.Attributes["Code"].InnerText;
                aAllowancesType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aAllowancesType.Name = node.InnerText;
                ListAllowancesTypes.Add(aAllowancesType);
            }
            return ListAllowancesTypes;
        }
        public ItemConstant SelectedAllowancesType(int ID)
        {

            ItemConstant aAllowancesType = new ItemConstant();
            foreach (var node in ListAllowancesTypes)
            {
                if (node.ID == ID)
                {
                    aAllowancesType = new ItemConstant();
                    aAllowancesType.Code = node.Code;
                    aAllowancesType.ID = node.ID;
                    aAllowancesType.Name = node.Name;
                    return aAllowancesType;
                }

            }

            return aAllowancesType;
        }
        public ItemConstant SelectedAllowancesType(string Code)
        {

            ItemConstant aAllowancesType = new ItemConstant();
            foreach (var node in ListAllowancesTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aAllowancesType = new ItemConstant();
                    aAllowancesType.Code = node.Code;
                    aAllowancesType.ID = node.ID;
                    aAllowancesType.Name = node.Name;
                    return aAllowancesType;
                }
            }
            return aAllowancesType;
        }

        //================================================================
        //================================================================
        public List<ItemConstant> LoadSalaryType()
        {
            ListSalaryTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Type);
            ItemConstant aSalaryType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListType/ContractsType/Type"))
            {
                aSalaryType = new ItemConstant();
                aSalaryType.Code = node.Attributes["Code"].InnerText;
                aSalaryType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aSalaryType.Name = node.InnerText;
                ListSalaryTypes.Add(aSalaryType);
            }
            return ListSalaryTypes;
        }
        public ItemConstant SelectedSalaryType(int ID)
        {

            ItemConstant aSalaryType = new ItemConstant();
            foreach (var node in ListSalaryTypes)
            {
                if (node.ID == ID)
                {
                    aSalaryType = new ItemConstant();
                    aSalaryType.Code = node.Code;
                    aSalaryType.ID = node.ID;
                    aSalaryType.Name = node.Name;
                    return aSalaryType;
                }

            }

            return aSalaryType;
        }
        public ItemConstant SelectedSalaryType(string Code)
        {

            ItemConstant aSalaryType = new ItemConstant();
            foreach (var node in ListSalaryTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aSalaryType = new ItemConstant();
                    aSalaryType.Code = node.Code;
                    aSalaryType.ID = node.ID;
                    aSalaryType.Name = node.Name;
                    return aSalaryType;
                }
            }
            return aSalaryType;
        }

        //================================================================
        //================================================================
        public List<ItemConstant> LoadRelationType()
        {
            ListRelationTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.RelationTypes);
            ItemConstant aRelationType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//RelationType"))
            {
                aRelationType = new ItemConstant();
                aRelationType.Code = node.Attributes["Code"].InnerText;
                aRelationType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aRelationType.Name = node.InnerText;
                ListRelationTypes.Add(aRelationType);
            }
            return ListRelationTypes;
        }
        public ItemConstant SelectedRelationType(int ID)
        {

            ItemConstant aRelationType = new ItemConstant();
            foreach (var node in ListRelationTypes)
            {
                if (node.ID == ID)
                {
                    aRelationType = new ItemConstant();
                    aRelationType.Code = node.Code;
                    aRelationType.ID = node.ID;
                    aRelationType.Name = node.Name;
                    return aRelationType;
                }

            }

            return aRelationType;
        }
        public ItemConstant SelectedRelationType(string Code)
        {

            ItemConstant aRelationType = new ItemConstant();
            foreach (var node in ListRelationTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aRelationType = new ItemConstant();
                    aRelationType.Code = node.Code;
                    aRelationType.ID = node.ID;
                    aRelationType.Name = node.Name;
                    return aRelationType;
                }
            }
            return aRelationType;
        }

        //================================================================
        //================================================================
        public List<ItemConstant> LoadDocumentSystemUsersType()
        {
            ListDocumentSystemUsersTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Type);
            ItemConstant aDocumentSystemUsersType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListType/DocumentSystemUsersType/Type"))
            {
                aDocumentSystemUsersType = new ItemConstant();
                aDocumentSystemUsersType.Code = node.Attributes["Code"].InnerText;
                aDocumentSystemUsersType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aDocumentSystemUsersType.Name = node.InnerText;
                ListDocumentSystemUsersTypes.Add(aDocumentSystemUsersType);
            }
            return ListDocumentSystemUsersTypes;
        }
        public ItemConstant SelectedDocumentSystemUsersType(int ID)
        {

            ItemConstant aDocumentSystemUsersType = new ItemConstant();
            foreach (var node in ListDocumentSystemUsersTypes)
            {
                if (node.ID == ID)
                {
                    aDocumentSystemUsersType = new ItemConstant();
                    aDocumentSystemUsersType.Code = node.Code;
                    aDocumentSystemUsersType.ID = node.ID;
                    aDocumentSystemUsersType.Name = node.Name;
                    return aDocumentSystemUsersType;
                }

            }

            return aDocumentSystemUsersType;
        }
        public ItemConstant SelectedDocumentSystemUsersType(string Code)
        {

            ItemConstant aDocumentSystemUsersType = new ItemConstant();
            foreach (var node in ListDocumentSystemUsersTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aDocumentSystemUsersType = new ItemConstant();
                    aDocumentSystemUsersType.Code = node.Code;
                    aDocumentSystemUsersType.ID = node.ID;
                    aDocumentSystemUsersType.Name = node.Name;
                    return aDocumentSystemUsersType;
                }
            }
            return aDocumentSystemUsersType;
        }

        public List<ItemConstant> LoadOrganizations()
        {
            ListOrganizations = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Organization);
            ItemConstant aOrganizations = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//Organization"))
            {
                aOrganizations = new ItemConstant();
                aOrganizations.Code = node.Attributes["Code"].InnerText;
                aOrganizations.ID = int.Parse(node.Attributes["ID"].InnerText);
                aOrganizations.Name = node.InnerText;
                ListOrganizations.Add(aOrganizations);
            }
            return ListOrganizations;
        }
        public ItemConstant SelectedOrganizations(int ID)
        {

            ItemConstant aOrganizations = new ItemConstant();
            foreach (var node in ListOrganizations)
            {
                if (node.ID == ID)
                {
                    aOrganizations = new ItemConstant();
                    aOrganizations.Code = node.Code;
                    aOrganizations.ID = node.ID;
                    aOrganizations.Name = node.Name;
                    return aOrganizations;
                }

            }

            return aOrganizations;
        }
        public ItemConstant SelectedOrganizations(string Code)
        {

            ItemConstant aOrganizations = new ItemConstant();
            foreach (var node in ListOrganizations)
            {
                if (node.Code == Code.ToString())
                {
                    aOrganizations = new ItemConstant();
                    aOrganizations.Code = node.Code;
                    aOrganizations.ID = node.ID;
                    aOrganizations.Name = node.Name;
                    return aOrganizations;
                }
            }
            return aOrganizations;
        }

        public List<ItemConstant> LoadSystemUsers_Certificates_Levels()
        {
            ListSystemUsers_Certificates_Levels = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.SystemUsers_Certificates_Level);
            ItemConstant aSystemUsers_Certificates_Level = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//Level"))
            {
                aSystemUsers_Certificates_Level = new ItemConstant();
                aSystemUsers_Certificates_Level.Code = node.Attributes["Code"].InnerText;
                aSystemUsers_Certificates_Level.ID = int.Parse(node.Attributes["ID"].InnerText);
                aSystemUsers_Certificates_Level.Name = node.InnerText;
                ListSystemUsers_Certificates_Levels.Add(aSystemUsers_Certificates_Level);
            }
            return ListSystemUsers_Certificates_Levels;
        }
        public ItemConstant SelectedSystemUsers_Certificates_Level(int ID)
        {

            ItemConstant aSystemUsers_Certificates_Level = new ItemConstant();
            foreach (var node in ListSystemUsers_Certificates_Levels)
            {
                if (node.ID == ID)
                {
                    aSystemUsers_Certificates_Level = new ItemConstant();
                    aSystemUsers_Certificates_Level.Code = node.Code;
                    aSystemUsers_Certificates_Level.ID = node.ID;
                    aSystemUsers_Certificates_Level.Name = node.Name;
                    return aSystemUsers_Certificates_Level;
                }

            }

            return aSystemUsers_Certificates_Level;
        }
        public ItemConstant SelectedSystemUsers_Certificates_Level(string Code)
        {

            ItemConstant aSystemUsers_Certificates_Level = new ItemConstant();
            foreach (var node in ListSystemUsers_Certificates_Levels)
            {
                if (node.Code == Code.ToString())
                {
                    aSystemUsers_Certificates_Level = new ItemConstant();
                    aSystemUsers_Certificates_Level.Code = node.Code;
                    aSystemUsers_Certificates_Level.ID = node.ID;
                    aSystemUsers_Certificates_Level.Name = node.Name;
                    return aSystemUsers_Certificates_Level;
                }
            }
            return aSystemUsers_Certificates_Level;
        }

        private List<ItemConstant> LoadServiceType()
        {
            ListServiceTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.ServiceTypes);
            ItemConstant aServiceType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//ServiceType"))
            {
                aServiceType = new ItemConstant();
                aServiceType.Code = node.Attributes["Code"].InnerText;
                aServiceType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aServiceType.Name = node.InnerText;
                ListServiceTypes.Add(aServiceType);
            }
            return ListServiceTypes;
        }
        public ItemConstant SelectedServiceType(int ID)
        {

            ItemConstant aServiceType = new ItemConstant();
            foreach (var node in ListServiceTypes)
            {
                if (node.ID == ID)
                {
                    aServiceType = new ItemConstant();
                    aServiceType.Code = node.Code;
                    aServiceType.ID = node.ID;
                    aServiceType.Name = node.Name;
                    return aServiceType;

                }

            }

            return aServiceType;
        }
        public ItemConstant SelectedServiceType(string Code)
        {

            ItemConstant aServiceType = new ItemConstant();
            foreach (var node in ListServiceTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aServiceType = new ItemConstant();
                    aServiceType.Code = node.Code;
                    aServiceType.ID = node.ID;
                    aServiceType.Name = node.Name;
                    return aServiceType;

                }

            }

            return aServiceType;
        }

        //Hiennv
        public List<ItemConstant> LoadExtraCost()
        {
            List<ItemConstant> ListExtraCost = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            FileInfo fileInfo = new FileInfo("ExtraCosts.xml");
            doc.Load(fileInfo.DirectoryName + "/ExtraCosts.xml");
            //doc.Load(Path.GetFullPath("ExtraCosts.xml"));
            ItemConstant aExtraCost = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//ExtraCost"))
            {
                aExtraCost = new ItemConstant();
                aExtraCost.ID = int.Parse(node.Attributes["ID"].InnerText);
                aExtraCost.Sku = node.Attributes["Sku"].InnerText;
                aExtraCost.NumberPepole = int.Parse(node.Attributes["NumberPepole"].InnerText);
                aExtraCost.ExtraValue = decimal.Parse(node.Attributes["ExtraValue"].InnerText);
                aExtraCost.CustomerType = int.Parse(node.Attributes["CustomerType"].InnerText);
                aExtraCost.PriceType = node.Attributes["PriceType"].InnerText;
                ListExtraCost.Add(aExtraCost);
            }
            return ListExtraCost;
        }
        


        //Hiennv
        public decimal SelectedExtraCost(string Sku, int NumberPepole, int customerType, string PriceType)
        {
            foreach (var node in this.LoadExtraCost())
            {
                if (node.Sku == Sku.ToString() && node.NumberPepole == NumberPepole && node.CustomerType == customerType && node.PriceType == PriceType)
                {
                    return node.ExtraValue;
                }
            }
            return 0;
        }
        //Hiennv
        public void InsertExtraCostRooms(string Sku, int NumberPepole, int CustomerType, decimal ExtraCostRooms, string PriceType)
        {
            try
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();

                doc.Load(Path.GetFullPath("ExtraCosts.xml"));

                XmlElement ExtraCost = doc.CreateElement("ExtraCost");

                XmlAttribute ID1 = doc.CreateAttribute("ID");
                ExtraCost.Attributes.Append(ID1);
                int count = this.LoadExtraCost().Select(r => r.ID).Max();
                ID1.InnerText = Convert.ToString(count + 1);

                XmlAttribute Sku1 = doc.CreateAttribute("Sku");
                ExtraCost.Attributes.Append(Sku1);
                Sku1.InnerText = Sku;

                XmlAttribute PriceType1 = doc.CreateAttribute("PriceType");
                ExtraCost.Attributes.Append(PriceType1);
                PriceType1.InnerText = PriceType;

                XmlAttribute NumberPepole1 = doc.CreateAttribute("NumberPepole");
                ExtraCost.Attributes.Append(NumberPepole1);
                NumberPepole1.InnerText = Convert.ToString(NumberPepole);

                XmlAttribute CustomerType1 = doc.CreateAttribute("CustomerType");
                ExtraCost.Attributes.Append(CustomerType1);
                CustomerType1.InnerText = Convert.ToString(CustomerType);

                XmlAttribute ExtraValue1 = doc.CreateAttribute("ExtraValue");
                ExtraCost.Attributes.Append(ExtraValue1);
                ExtraValue1.InnerText = Convert.ToString(ExtraCostRooms);

                doc.DocumentElement.AppendChild(ExtraCost);

                // Save the document to a file. White space is 
                // preserved (no white space).
                //doc.PreserveWhitespace = true;

                doc.Save(Path.GetFullPath("ExtraCosts.xml"));
            }
            catch (Exception ex)
            {
                throw new Exception("ConstantsXML.InsertExtraCostRooms:" + ex.ToString());
            }
        }
        //Hiennv
        public void UpdateExtraCostRooms(int ID, string Sku, int NumberPepole, int CustomerType, decimal ExtraCostRooms, string PriceType)
        {
            try
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.GetFullPath("ExtraCosts.xml"));
                foreach (XmlNode node in doc.SelectNodes("//ExtraCost"))
                {
                    if (node.Attributes["ID"].Value.Equals(Convert.ToString(ID)))
                    {
                        node.Attributes["NumberPepole"].Value = Convert.ToString(NumberPepole);
                        node.Attributes["CustomerType"].Value = Convert.ToString(CustomerType);
                        node.Attributes["ExtraValue"].Value = Convert.ToString(ExtraCostRooms);
                        node.Attributes["PriceType"].Value = Convert.ToString(PriceType);
                    }
                }
                
                // Save the document to a file. White space is 
                doc.Save(Path.GetFullPath("ExtraCosts.xml"));
            }
            catch (Exception ex)
            {
                throw new Exception("ConstantsXML.UpdateExtraCostRooms:" + ex.ToString());
            }
        }
        //Hiennv
        public void DeleteExtraCostRooms(int ID)
        {
            try
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();
                doc.Load(Path.GetFullPath("ExtraCosts.xml"));
                foreach (XmlNode node in doc.SelectNodes("//ExtraCost"))
                {
                    if (node.Attributes["ID"].Value.Equals(Convert.ToString(ID)))
                    {
                        doc.DocumentElement.RemoveChild(node);
                    } 
                }
                // Save the document to a file. White space is 
                doc.Save(Path.GetFullPath("ExtraCosts.xml"));
            }
            catch (Exception ex)
            {
                throw new Exception("ConstantsXML.DeleteExtraCostRooms:" + ex.ToString());
            }
        }







        #region SaleManagement
        //================================================================
        private List<ItemConstant> LoadHallType()
        {
            ListHallTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.HallTypes);
            ItemConstant aHallType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//HallType"))
            {
                aHallType = new ItemConstant();
                aHallType.Code = node.Attributes["Code"].InnerText;
                aHallType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aHallType.Name = node.InnerText;
                ListHallTypes.Add(aHallType);
            }
            return ListHallTypes;
        }
        public ItemConstant SelectedHallType(int ID)
        {

            ItemConstant aHallType = new ItemConstant();
            foreach (var node in ListHallTypes)
            {
                if (node.ID == ID)
                {
                    aHallType = new ItemConstant();
                    aHallType.Code = node.Code;
                    aHallType.ID = node.ID;
                    aHallType.Name = node.Name;
                    return aHallType;

                }

            }

            return aHallType;
        }
        public ItemConstant SelectedHallType(string Code)
        {

            ItemConstant aHallType = new ItemConstant();
            foreach (var node in ListHallTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aHallType = new ItemConstant();
                    aHallType.Code = node.Code;
                    aHallType.ID = node.ID;
                    aHallType.Name = node.Name;
                    return aHallType;

                }

            }

            return aHallType;
        }

        //================================================================
        //================================================================
        private List<ItemConstant> LoadBookingHallStatus()
        {
            ListBookingHallStatus = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aBookingHallStatus = new ItemConstant();


            foreach (XmlNode node in doc.SelectNodes("/ListStatus/BookingHallStatus/Status"))
            {
                aBookingHallStatus = new ItemConstant();
                aBookingHallStatus.Code = node.Attributes["Code"].InnerText;
                aBookingHallStatus.ID = int.Parse(node.Attributes["ID"].InnerText);
                aBookingHallStatus.Name = node.InnerText;
                ListBookingHallStatus.Add(aBookingHallStatus);
            }
            return ListBookingHallStatus;
        }
        public ItemConstant SelectedBookingHallStatus(int ID)
        {

            ItemConstant aBookingHallStatus = new ItemConstant();
            foreach (var node in ListBookingHallStatus)
            {
                if (node.ID == ID)
                {
                    aBookingHallStatus = new ItemConstant();
                    aBookingHallStatus.Code = node.Code;
                    aBookingHallStatus.ID = node.ID;
                    aBookingHallStatus.Name = node.Name;
                    return aBookingHallStatus;
                }

            }

            return aBookingHallStatus;
        }
        public ItemConstant SelectedBookingHallStatus(string Code)
        {

            ItemConstant aBookingHallStatus = new ItemConstant();
            foreach (var node in ListBookingHallStatus)
            {
                if (node.Code == Code.ToString())
                {
                    aBookingHallStatus = new ItemConstant();
                    aBookingHallStatus.Code = node.Code;
                    aBookingHallStatus.ID = node.ID;
                    aBookingHallStatus.Name = node.Name;
                    return aBookingHallStatus;

                }

            }

            return aBookingHallStatus;
        }
        //================================================================
        //================================================================
        public List<ItemConstant> LoadBookingType()
        {
            ListBookingTypes = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.BookingType);
            ItemConstant aBookingType = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("//BookingType"))
            {
                aBookingType = new ItemConstant();
                aBookingType.Code = node.Attributes["Code"].InnerText;
                aBookingType.ID = int.Parse(node.Attributes["ID"].InnerText);
                aBookingType.Name = node.InnerText;
                ListBookingTypes.Add(aBookingType);
            }
            return ListBookingTypes;
        }
        public ItemConstant SelectedBookingType(int ID)
        {

            ItemConstant aBookingType = new ItemConstant();
            foreach (var node in ListBookingTypes)
            {
                if (node.ID == ID)
                {
                    aBookingType = new ItemConstant();
                    aBookingType.Code = node.Code;
                    aBookingType.ID = node.ID;
                    aBookingType.Name = node.Name;
                    return aBookingType;
                }

            }

            return aBookingType;
        }
        public ItemConstant SelectedBookingType(string Code)
        {

            ItemConstant aBookingType = new ItemConstant();
            foreach (var node in ListBookingTypes)
            {
                if (node.Code == Code.ToString())
                {
                    aBookingType = new ItemConstant();
                    aBookingType.Code = node.Code;
                    aBookingType.ID = node.ID;
                    aBookingType.Name = node.Name;
                    return aBookingType;
                }
            }
            return aBookingType;
        }

        //================================================================
        //================================================================
        private List<ItemConstant> LoadBookingHStatus()
        {
            ListBookingHStatus = new List<ItemConstant>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Status);
            ItemConstant aBookingHStatus = new ItemConstant();
            foreach (XmlNode node in doc.SelectNodes("/ListStatus/BookingHStatus/Status"))
            {
                aBookingHStatus = new ItemConstant();
                aBookingHStatus.Code = node.Attributes["Code"].InnerText;
                aBookingHStatus.ID = int.Parse(node.Attributes["ID"].InnerText);
                aBookingHStatus.Name = node.InnerText;
                ListBookingHStatus.Add(aBookingHStatus);
            }
            return ListBookingHStatus;
        }
        public ItemConstant SelectedBookingHStatus(int ID)
        {

            ItemConstant aBookingHStatus = new ItemConstant();
            foreach (var node in ListBookingHStatus)
            {
                if (node.ID == ID)
                {
                    aBookingHStatus = new ItemConstant();
                    aBookingHStatus.Code = node.Code;
                    aBookingHStatus.ID = node.ID;
                    aBookingHStatus.Name = node.Name;
                    return aBookingHStatus;

                }

            }

            return aBookingHStatus;
        }
        public ItemConstant SelectedBookingHStatus(string Code)
        {

            ItemConstant aBookingHStatus = new ItemConstant();
            foreach (var node in ListBookingHStatus)
            {
                if (node.Code == Code.ToString())
                {
                    aBookingHStatus = new ItemConstant();
                    aBookingHStatus.Code = node.Code;
                    aBookingHStatus.ID = node.ID;
                    aBookingHStatus.Name = node.Name;
                    return aBookingHStatus;

                }

            }

            return aBookingHStatus;
        }
        //================================================================
        //================================================================
        public List<ItemConstant> LoadLevel_ByID(int ID)
        {
            List<ItemConstant> ListLevels1 = new List<ItemConstant>();
            ItemConstant aLevel = new ItemConstant();
            foreach (var node in ListLevels)
            {
                if (node.ID <= ID)
                {
                    aLevel = new ItemConstant();
                    aLevel.Code = node.Code;
                    aLevel.ID = node.ID;
                    aLevel.Name = node.Name;
                    ListLevels1.Add(aLevel);

                }
            }
            return ListLevels1;
        }
        #endregion


    }
}
