using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCare.Server.BLL;

namespace HCare.Structure
{
    public class ServerObject : ITaskManager
    {
        public object Execute(string methodName, object param)
        {
            //throw new NotImplementedException();
            switch (methodName)
            {
                #region Auto Generated - HC_Users
                case HCareTaks.AG_SaveHcUsersInfo:
                    HcUsersBLL hcUsersBLL = null;
                    hcUsersBLL = new HcUsersBLL();
                    return hcUsersBLL.SaveHcUsersInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcUsersInfo:
                    hcUsersBLL = new HcUsersBLL();
                    return hcUsersBLL.UpdateHcUsersInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcUsersInfoById:
                    hcUsersBLL = new HcUsersBLL();
                    return hcUsersBLL.DeleteHcUsersInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcUsersRecord:
                    hcUsersBLL = new HcUsersBLL();
                    return hcUsersBLL.GetAllHcUsersRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcUsersRecordById:
                    hcUsersBLL = new HcUsersBLL();
                    return hcUsersBLL.GetSingleHcUsersRecordById(param);
                    break;
                #endregion

                #region Auto Generated - Adm_Menu
                case HCareTaks.AG_SaveAdmMenuInfo:
                    AdmMenuBLL admMenuBLL = null;
                    admMenuBLL = new AdmMenuBLL();
                    return admMenuBLL.SaveAdmMenuInfo(param);
                    break;
                case HCareTaks.AG_UpdateAdmMenuInfo:
                    admMenuBLL = new AdmMenuBLL();
                    return admMenuBLL.UpdateAdmMenuInfo(param);
                    break;
                case HCareTaks.AG_DeleteAdmMenuInfoById:
                    admMenuBLL = new AdmMenuBLL();
                    return admMenuBLL.DeleteAdmMenuInfoById(param);
                    break;
                case HCareTaks.AG_GetAllAdmMenuRecord:
                    admMenuBLL = new AdmMenuBLL();
                    return admMenuBLL.GetAllAdmMenuRecord(param);
                    break;
                case HCareTaks.AG_GetSingleAdmMenuRecordById:
                    admMenuBLL = new AdmMenuBLL();
                    return admMenuBLL.GetSingleAdmMenuRecordById(param);
                    break;
                #endregion

                #region Auto Generated - Adm_MenuSub
                case HCareTaks.AG_SaveAdmMenusubInfo:
                    AdmMenusubBLL admMenusubBLL = null;
                    admMenusubBLL = new AdmMenusubBLL();
                    return admMenusubBLL.SaveAdmMenusubInfo(param);
                    break;
                case HCareTaks.AG_UpdateAdmMenusubInfo:
                    admMenusubBLL = new AdmMenusubBLL();
                    return admMenusubBLL.UpdateAdmMenusubInfo(param);
                    break;
                case HCareTaks.AG_DeleteAdmMenusubInfoById:
                    admMenusubBLL = new AdmMenusubBLL();
                    return admMenusubBLL.DeleteAdmMenusubInfoById(param);
                    break;
                case HCareTaks.AG_GetAllAdmMenusubRecord:
                    admMenusubBLL = new AdmMenusubBLL();
                    return admMenusubBLL.GetAllAdmMenusubRecord(param);
                    break;
                case HCareTaks.AG_GetSingleAdmMenusubRecordById:
                    admMenusubBLL = new AdmMenusubBLL();
                    return admMenusubBLL.GetSingleAdmMenusubRecordById(param);
                    break;
                #endregion

                #region Auto Generated - Adm_RoleDetails
                case HCareTaks.AG_SaveAdmRoledetailsInfo:
                    AdmRoledetailsBLL admRoledetailsBLL = null;
                    admRoledetailsBLL = new AdmRoledetailsBLL();
                    return admRoledetailsBLL.SaveAdmRoledetailsInfo(param);
                    break;
                case HCareTaks.AG_UpdateAdmRoledetailsInfo:
                    admRoledetailsBLL = new AdmRoledetailsBLL();
                    return admRoledetailsBLL.UpdateAdmRoledetailsInfo(param);
                    break;
                case HCareTaks.AG_DeleteAdmRoledetailsInfoById:
                    admRoledetailsBLL = new AdmRoledetailsBLL();
                    return admRoledetailsBLL.DeleteAdmRoledetailsInfoById(param);
                    break;
                case HCareTaks.AG_GetAllAdmRoledetailsRecord:
                    admRoledetailsBLL = new AdmRoledetailsBLL();
                    return admRoledetailsBLL.GetAllAdmRoledetailsRecord(param);
                    break;
                case HCareTaks.AG_GetSingleAdmRoledetailsRecordById:
                    admRoledetailsBLL = new AdmRoledetailsBLL();
                    return admRoledetailsBLL.GetSingleAdmRoledetailsRecordById(param);
                    break;
                #endregion

                #region Auto Generated - Adm_RoleMaster
                case HCareTaks.AG_SaveAdmRolemasterInfo:
                    AdmRolemasterBLL admRolemasterBLL = null;
                    admRolemasterBLL = new AdmRolemasterBLL();
                    return admRolemasterBLL.SaveAdmRolemasterInfo(param);
                    break;
                case HCareTaks.AG_UpdateAdmRolemasterInfo:
                    admRolemasterBLL = new AdmRolemasterBLL();
                    return admRolemasterBLL.UpdateAdmRolemasterInfo(param);
                    break;
                case HCareTaks.AG_DeleteAdmRolemasterInfoById:
                    admRolemasterBLL = new AdmRolemasterBLL();
                    return admRolemasterBLL.DeleteAdmRolemasterInfoById(param);
                    break;
                case HCareTaks.AG_GetAllAdmRolemasterRecord:
                    admRolemasterBLL = new AdmRolemasterBLL();
                    return admRolemasterBLL.GetAllAdmRolemasterRecord(param);
                    break;
                case HCareTaks.AG_GetSingleAdmRolemasterRecordById:
                    admRolemasterBLL = new AdmRolemasterBLL();
                    return admRolemasterBLL.GetSingleAdmRolemasterRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_DoctorInfo
                case HCareTaks.AG_SaveHcDoctorinfoInfo:
                    HcDoctorinfoBLL hcDoctorinfoBLL = null;
                    hcDoctorinfoBLL = new HcDoctorinfoBLL();
                    return hcDoctorinfoBLL.SaveHcDoctorinfoInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDoctorinfoInfo:
                    hcDoctorinfoBLL = new HcDoctorinfoBLL();
                    return hcDoctorinfoBLL.UpdateHcDoctorinfoInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDoctorinfoInfoById:
                    hcDoctorinfoBLL = new HcDoctorinfoBLL();
                    return hcDoctorinfoBLL.DeleteHcDoctorinfoInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDoctorinfoRecord:
                    hcDoctorinfoBLL = new HcDoctorinfoBLL();
                    return hcDoctorinfoBLL.GetAllHcDoctorinfoRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDoctorinfoRecordById:
                    hcDoctorinfoBLL = new HcDoctorinfoBLL();
                    return hcDoctorinfoBLL.GetSingleHcDoctorinfoRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Services
                case HCareTaks.AG_SaveHcServicesInfo:
                    HcServicesBLL hcServicesBLL = null;
                    hcServicesBLL = new HcServicesBLL();
                    return hcServicesBLL.SaveHcServicesInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcServicesInfo:
                    hcServicesBLL = new HcServicesBLL();
                    return hcServicesBLL.UpdateHcServicesInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcServicesInfoById:
                    hcServicesBLL = new HcServicesBLL();
                    return hcServicesBLL.DeleteHcServicesInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcServicesRecord:
                    hcServicesBLL = new HcServicesBLL();
                    return hcServicesBLL.GetAllHcServicesRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcServicesRecordById:
                    hcServicesBLL = new HcServicesBLL();
                    return hcServicesBLL.GetSingleHcServicesRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Doctor_Appointment
                case HCareTaks.AG_SaveHcDoctorAppointmentInfo:
                    HcDoctorAppointmentBLL hcDoctorAppointmentBLL = null;
                    hcDoctorAppointmentBLL = new HcDoctorAppointmentBLL();
                    return hcDoctorAppointmentBLL.SaveHcDoctorAppointmentInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDoctorAppointmentInfo:
                    hcDoctorAppointmentBLL = new HcDoctorAppointmentBLL();
                    return hcDoctorAppointmentBLL.UpdateHcDoctorAppointmentInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDoctorAppointmentInfoById:
                    hcDoctorAppointmentBLL = new HcDoctorAppointmentBLL();
                    return hcDoctorAppointmentBLL.DeleteHcDoctorAppointmentInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDoctorAppointmentRecord:
                    hcDoctorAppointmentBLL = new HcDoctorAppointmentBLL();
                    return hcDoctorAppointmentBLL.GetAllHcDoctorAppointmentRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDoctorAppointmentRecordById:
                    hcDoctorAppointmentBLL = new HcDoctorAppointmentBLL();
                    return hcDoctorAppointmentBLL.GetSingleHcDoctorAppointmentRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Doctor_Departments
                case HCareTaks.AG_SaveHcDoctorDepartmentsInfo:
                    HcDoctorDepartmentsBLL hcDoctorDepartmentsBLL = null;
                    hcDoctorDepartmentsBLL = new HcDoctorDepartmentsBLL();
                    return hcDoctorDepartmentsBLL.SaveHcDoctorDepartmentsInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDoctorDepartmentsInfo:
                    hcDoctorDepartmentsBLL = new HcDoctorDepartmentsBLL();
                    return hcDoctorDepartmentsBLL.UpdateHcDoctorDepartmentsInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDoctorDepartmentsInfoById:
                    hcDoctorDepartmentsBLL = new HcDoctorDepartmentsBLL();
                    return hcDoctorDepartmentsBLL.DeleteHcDoctorDepartmentsInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDoctorDepartmentsRecord:
                    hcDoctorDepartmentsBLL = new HcDoctorDepartmentsBLL();
                    return hcDoctorDepartmentsBLL.GetAllHcDoctorDepartmentsRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDoctorDepartmentsRecordById:
                    hcDoctorDepartmentsBLL = new HcDoctorDepartmentsBLL();
                    return hcDoctorDepartmentsBLL.GetSingleHcDoctorDepartmentsRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Doctor_Times
                case HCareTaks.AG_SaveHcDoctorTimesInfo:
                    HcDoctorTimesBLL hcDoctorTimesBLL = null;
                    hcDoctorTimesBLL = new HcDoctorTimesBLL();
                    return hcDoctorTimesBLL.SaveHcDoctorTimesInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDoctorTimesInfo:
                    hcDoctorTimesBLL = new HcDoctorTimesBLL();
                    return hcDoctorTimesBLL.UpdateHcDoctorTimesInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDoctorTimesInfoById:
                    hcDoctorTimesBLL = new HcDoctorTimesBLL();
                    return hcDoctorTimesBLL.DeleteHcDoctorTimesInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDoctorTimesRecord:
                    hcDoctorTimesBLL = new HcDoctorTimesBLL();
                    return hcDoctorTimesBLL.GetAllHcDoctorTimesRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDoctorTimesRecordById:
                    hcDoctorTimesBLL = new HcDoctorTimesBLL();
                    return hcDoctorTimesBLL.GetSingleHcDoctorTimesRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Lab_test
                case HCareTaks.AG_SaveHcLabTestInfo:
                    HcLabTestBLL hcLabTestBLL = null;
                    hcLabTestBLL = new HcLabTestBLL();
                    return hcLabTestBLL.SaveHcLabTestInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcLabTestInfo:
                    hcLabTestBLL = new HcLabTestBLL();
                    return hcLabTestBLL.UpdateHcLabTestInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcLabTestInfoById:
                    hcLabTestBLL = new HcLabTestBLL();
                    return hcLabTestBLL.DeleteHcLabTestInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcLabTestRecord:
                    hcLabTestBLL = new HcLabTestBLL();
                    return hcLabTestBLL.GetAllHcLabTestRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcLabTestRecordById:
                    hcLabTestBLL = new HcLabTestBLL();
                    return hcLabTestBLL.GetSingleHcLabTestRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Test_category
                case HCareTaks.AG_SaveHcTestCategoryInfo:
                    HcTestCategoryBLL hcTestCategoryBLL = null;
                    hcTestCategoryBLL = new HcTestCategoryBLL();
                    return hcTestCategoryBLL.SaveHcTestCategoryInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcTestCategoryInfo:
                    hcTestCategoryBLL = new HcTestCategoryBLL();
                    return hcTestCategoryBLL.UpdateHcTestCategoryInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcTestCategoryInfoById:
                    hcTestCategoryBLL = new HcTestCategoryBLL();
                    return hcTestCategoryBLL.DeleteHcTestCategoryInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcTestCategoryRecord:
                    hcTestCategoryBLL = new HcTestCategoryBLL();
                    return hcTestCategoryBLL.GetAllHcTestCategoryRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcTestCategoryRecordById:
                    hcTestCategoryBLL = new HcTestCategoryBLL();
                    return hcTestCategoryBLL.GetSingleHcTestCategoryRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_UserLabTest
                case HCareTaks.AG_SaveHcUserlabtestInfo:
                    HcUserlabtestBLL hcUserlabtestBLL = null;
                    hcUserlabtestBLL = new HcUserlabtestBLL();
                    return hcUserlabtestBLL.SaveHcUserlabtestInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcUserlabtestInfo:
                    hcUserlabtestBLL = new HcUserlabtestBLL();
                    return hcUserlabtestBLL.UpdateHcUserlabtestInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcUserlabtestInfoById:
                    hcUserlabtestBLL = new HcUserlabtestBLL();
                    return hcUserlabtestBLL.DeleteHcUserlabtestInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcUserlabtestRecord:
                    hcUserlabtestBLL = new HcUserlabtestBLL();
                    return hcUserlabtestBLL.GetAllHcUserlabtestRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcUserlabtestRecordById:
                    hcUserlabtestBLL = new HcUserlabtestBLL();
                    return hcUserlabtestBLL.GetSingleHcUserlabtestRecordById(param);
                    break;
              
                #endregion

                #region Auto Generated - HC_Medicine
                case HCareTaks.AG_SaveHcMedicineInfo:
                    HcMedicineBLL hcMedicineBLL = null;
                    hcMedicineBLL = new HcMedicineBLL();
                    return hcMedicineBLL.SaveHcMedicineInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcMedicineInfo:
                    hcMedicineBLL = new HcMedicineBLL();
                    return hcMedicineBLL.UpdateHcMedicineInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcMedicineInfoById:
                    hcMedicineBLL = new HcMedicineBLL();
                    return hcMedicineBLL.DeleteHcMedicineInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcMedicineRecord:
                    hcMedicineBLL = new HcMedicineBLL();
                    return hcMedicineBLL.GetAllHcMedicineRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcMedicineRecordById:
                    hcMedicineBLL = new HcMedicineBLL();
                    return hcMedicineBLL.GetSingleHcMedicineRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_MedicineType
                case HCareTaks.AG_SaveHcMedicinetypeInfo:
                    HcMedicinetypeBLL hcMedicinetypeBLL = null;
                    hcMedicinetypeBLL = new HcMedicinetypeBLL();
                    return hcMedicinetypeBLL.SaveHcMedicinetypeInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcMedicinetypeInfo:
                    hcMedicinetypeBLL = new HcMedicinetypeBLL();
                    return hcMedicinetypeBLL.UpdateHcMedicinetypeInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcMedicinetypeInfoById:
                    hcMedicinetypeBLL = new HcMedicinetypeBLL();
                    return hcMedicinetypeBLL.DeleteHcMedicinetypeInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcMedicinetypeRecord:
                    hcMedicinetypeBLL = new HcMedicinetypeBLL();
                    return hcMedicinetypeBLL.GetAllHcMedicinetypeRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcMedicinetypeRecordById:
                    hcMedicinetypeBLL = new HcMedicinetypeBLL();
                    return hcMedicinetypeBLL.GetSingleHcMedicinetypeRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_ProductCategory
                case HCareTaks.AG_SaveHcProductcategoryInfo:
                    HcProductcategoryBLL hcProductcategoryBLL = null;
                    hcProductcategoryBLL = new HcProductcategoryBLL();
                    return hcProductcategoryBLL.SaveHcProductcategoryInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcProductcategoryInfo:
                    hcProductcategoryBLL = new HcProductcategoryBLL();
                    return hcProductcategoryBLL.UpdateHcProductcategoryInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcProductcategoryInfoById:
                    hcProductcategoryBLL = new HcProductcategoryBLL();
                    return hcProductcategoryBLL.DeleteHcProductcategoryInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcProductcategoryRecord:
                    hcProductcategoryBLL = new HcProductcategoryBLL();
                    return hcProductcategoryBLL.GetAllHcProductcategoryRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcProductcategoryRecordById:
                    hcProductcategoryBLL = new HcProductcategoryBLL();
                    return hcProductcategoryBLL.GetSingleHcProductcategoryRecordById(param);
                    break;
                #endregion


               
                    

                #region Auto Generated - HC_ProductCart
                case HCareTaks.AG_SaveHcProductcartInfo:
                    HcProductcartBLL hcProductcartBLL = null;
                    hcProductcartBLL = new HcProductcartBLL();
                    return hcProductcartBLL.SaveHcProductcartInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcProductcartInfo:
                    hcProductcartBLL = new HcProductcartBLL();
                    return hcProductcartBLL.UpdateHcProductcartInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcProductcartInfoById:
                    hcProductcartBLL = new HcProductcartBLL();
                    return hcProductcartBLL.DeleteHcProductcartInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcProductcartRecord:
                    hcProductcartBLL = new HcProductcartBLL();
                    return hcProductcartBLL.GetAllHcProductcartRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcProductcartRecordById:
                    hcProductcartBLL = new HcProductcartBLL();
                    return hcProductcartBLL.GetSingleHcProductcartRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_ProductOrder
                case HCareTaks.AG_SaveHcProductorderInfo:
                    HcProductorderBLL hcProductorderBLL = null;
                    hcProductorderBLL = new HcProductorderBLL();
                    return hcProductorderBLL.SaveHcProductorderInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcProductorderInfo:
                    hcProductorderBLL = new HcProductorderBLL();
                    return hcProductorderBLL.UpdateHcProductorderInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcProductorderInfoById:
                    hcProductorderBLL = new HcProductorderBLL();
                    return hcProductorderBLL.DeleteHcProductorderInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcProductorderRecord:
                    hcProductorderBLL = new HcProductorderBLL();
                    return hcProductorderBLL.GetAllHcProductorderRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcProductorderRecordById:
                    hcProductorderBLL = new HcProductorderBLL();
                    return hcProductorderBLL.GetSingleHcProductorderRecordById(param);
                    break;
                #endregion
/*
                #region Auto Generated - HC_ProductDelivery
                case HCareTaks.AG_SaveHcProductdeliveryInfo:
                    HcProductdeliveryBLL hcProductdeliveryBLL = null;
                    hcProductdeliveryBLL = new HcProductdeliveryBLL();
                    return hcProductdeliveryBLL.SaveHcProductdeliveryInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcProductdeliveryInfo:
                    hcProductdeliveryBLL = new HcProductdeliveryBLL();
                    return hcProductdeliveryBLL.UpdateHcProductdeliveryInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcProductdeliveryInfoById:
                    hcProductdeliveryBLL = new HcProductdeliveryBLL();
                    return hcProductdeliveryBLL.DeleteHcProductdeliveryInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcProductdeliveryRecord:
                    hcProductdeliveryBLL = new HcProductdeliveryBLL();
                    return hcProductdeliveryBLL.GetAllHcProductdeliveryRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcProductdeliveryRecordById:
                    hcProductdeliveryBLL = new HcProductdeliveryBLL();
                    return hcProductdeliveryBLL.GetSingleHcProductdeliveryRecordById(param);
                    break;
                #endregion

               

                #region Auto Generated - HC_PaymentInfo
                case HCareTaks.AG_SaveHcPaymentinfoInfo:
                    HcPaymentinfoBLL hcPaymentinfoBLL = null;
                    hcPaymentinfoBLL = new HcPaymentinfoBLL();
                    return hcPaymentinfoBLL.SaveHcPaymentinfoInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcPaymentinfoInfo:
                    hcPaymentinfoBLL = new HcPaymentinfoBLL();
                    return hcPaymentinfoBLL.UpdateHcPaymentinfoInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcPaymentinfoInfoById:
                    hcPaymentinfoBLL = new HcPaymentinfoBLL();
                    return hcPaymentinfoBLL.DeleteHcPaymentinfoInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcPaymentinfoRecord:
                    hcPaymentinfoBLL = new HcPaymentinfoBLL();
                    return hcPaymentinfoBLL.GetAllHcPaymentinfoRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcPaymentinfoRecordById:
                    hcPaymentinfoBLL = new HcPaymentinfoBLL();
                    return hcPaymentinfoBLL.GetSingleHcPaymentinfoRecordById(param);
                    break;
                #endregion
                    */


                #region Auto Generated - HC_ServiceCenter
                case HCareTaks.AG_SaveHcServicecenterInfo:
                    HcServicecenterBLL hcServicecenterBLL = null;
                    hcServicecenterBLL = new HcServicecenterBLL();
                    return hcServicecenterBLL.SaveHcServicecenterInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcServicecenterInfo:
                    hcServicecenterBLL = new HcServicecenterBLL();
                    return hcServicecenterBLL.UpdateHcServicecenterInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcServicecenterInfoById:
                    hcServicecenterBLL = new HcServicecenterBLL();
                    return hcServicecenterBLL.DeleteHcServicecenterInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcServicecenterRecord:
                    hcServicecenterBLL = new HcServicecenterBLL();
                    return hcServicecenterBLL.GetAllHcServicecenterRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcServicecenterRecordById:
                    hcServicecenterBLL = new HcServicecenterBLL();
                    return hcServicecenterBLL.GetSingleHcServicecenterRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_EmergencyContact
                case HCareTaks.AG_SaveHcEmergencycontactInfo:
                    HcEmergencycontactBLL hcEmergencycontactBLL = null;
                    hcEmergencycontactBLL = new HcEmergencycontactBLL();
                    return hcEmergencycontactBLL.SaveHcEmergencycontactInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcEmergencycontactInfo:
                    hcEmergencycontactBLL = new HcEmergencycontactBLL();
                    return hcEmergencycontactBLL.UpdateHcEmergencycontactInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcEmergencycontactInfoById:
                    hcEmergencycontactBLL = new HcEmergencycontactBLL();
                    return hcEmergencycontactBLL.DeleteHcEmergencycontactInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcEmergencycontactRecord:
                    hcEmergencycontactBLL = new HcEmergencycontactBLL();
                    return hcEmergencycontactBLL.GetAllHcEmergencycontactRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcEmergencycontactRecordById:
                    hcEmergencycontactBLL = new HcEmergencycontactBLL();
                    return hcEmergencycontactBLL.GetSingleHcEmergencycontactRecordById(param);
                    break;
                #endregion

                //17 jan 2021
                #region Auto Generated - HC_Assesment
                case HCareTaks.AG_SaveHcAssesmentInfo:
                    HcAssesmentBLL hcAssesmentBLL = null;
                    hcAssesmentBLL = new HcAssesmentBLL();
                    return hcAssesmentBLL.SaveHcAssesmentInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcAssesmentInfo:
                    hcAssesmentBLL = new HcAssesmentBLL();
                    return hcAssesmentBLL.UpdateHcAssesmentInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcAssesmentInfoById:
                    hcAssesmentBLL = new HcAssesmentBLL();
                    return hcAssesmentBLL.DeleteHcAssesmentInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcAssesmentRecord:
                    hcAssesmentBLL = new HcAssesmentBLL();
                    return hcAssesmentBLL.GetAllHcAssesmentRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcAssesmentRecordById:
                    hcAssesmentBLL = new HcAssesmentBLL();
                    return hcAssesmentBLL.GetSingleHcAssesmentRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_CommunicationChannel
                case HCareTaks.AG_SaveHcCommunicationchannelInfo:
                    HcCommunicationchannelBLL hcCommunicationchannelBLL = null;
                    hcCommunicationchannelBLL = new HcCommunicationchannelBLL();
                    return hcCommunicationchannelBLL.SaveHcCommunicationchannelInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcCommunicationchannelInfo:
                    hcCommunicationchannelBLL = new HcCommunicationchannelBLL();
                    return hcCommunicationchannelBLL.UpdateHcCommunicationchannelInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcCommunicationchannelInfoById:
                    hcCommunicationchannelBLL = new HcCommunicationchannelBLL();
                    return hcCommunicationchannelBLL.DeleteHcCommunicationchannelInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcCommunicationchannelRecord:
                    hcCommunicationchannelBLL = new HcCommunicationchannelBLL();
                    return hcCommunicationchannelBLL.GetAllHcCommunicationchannelRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcCommunicationchannelRecordById:
                    hcCommunicationchannelBLL = new HcCommunicationchannelBLL();
                    return hcCommunicationchannelBLL.GetSingleHcCommunicationchannelRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Country
                case HCareTaks.AG_SaveHcCountryInfo:
                    HcCountryBLL hcCountryBLL = null;
                    hcCountryBLL = new HcCountryBLL();
                    return hcCountryBLL.SaveHcCountryInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcCountryInfo:
                    hcCountryBLL = new HcCountryBLL();
                    return hcCountryBLL.UpdateHcCountryInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcCountryInfoById:
                    hcCountryBLL = new HcCountryBLL();
                    return hcCountryBLL.DeleteHcCountryInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcCountryRecord:
                    hcCountryBLL = new HcCountryBLL();
                    return hcCountryBLL.GetAllHcCountryRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcCountryRecordById:
                    hcCountryBLL = new HcCountryBLL();
                    return hcCountryBLL.GetSingleHcCountryRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Diseases
                case HCareTaks.AG_SaveHcDiseasesInfo:
                    HcDiseasesBLL hcDiseasesBLL = null;
                    hcDiseasesBLL = new HcDiseasesBLL();
                    return hcDiseasesBLL.SaveHcDiseasesInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDiseasesInfo:
                    hcDiseasesBLL = new HcDiseasesBLL();
                    return hcDiseasesBLL.UpdateHcDiseasesInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDiseasesInfoById:
                    hcDiseasesBLL = new HcDiseasesBLL();
                    return hcDiseasesBLL.DeleteHcDiseasesInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDiseasesRecord:
                    hcDiseasesBLL = new HcDiseasesBLL();
                    return hcDiseasesBLL.GetAllHcDiseasesRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDiseasesRecordById:
                    hcDiseasesBLL = new HcDiseasesBLL();
                    return hcDiseasesBLL.GetSingleHcDiseasesRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_DoctorAssesment
                case HCareTaks.AG_SaveHcDoctorassesmentInfo:
                    HcDoctorassesmentBLL hcDoctorassesmentBLL = null;
                    hcDoctorassesmentBLL = new HcDoctorassesmentBLL();
                    return hcDoctorassesmentBLL.SaveHcDoctorassesmentInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcDoctorassesmentInfo:
                    hcDoctorassesmentBLL = new HcDoctorassesmentBLL();
                    return hcDoctorassesmentBLL.UpdateHcDoctorassesmentInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcDoctorassesmentInfoById:
                    hcDoctorassesmentBLL = new HcDoctorassesmentBLL();
                    return hcDoctorassesmentBLL.DeleteHcDoctorassesmentInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcDoctorassesmentRecord:
                    hcDoctorassesmentBLL = new HcDoctorassesmentBLL();
                    return hcDoctorassesmentBLL.GetAllHcDoctorassesmentRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcDoctorassesmentRecordById:
                    hcDoctorassesmentBLL = new HcDoctorassesmentBLL();
                    return hcDoctorassesmentBLL.GetSingleHcDoctorassesmentRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_MedicaHistory
                case HCareTaks.AG_SaveHcMedicahistoryInfo:
                    HcMedicahistoryBLL hcMedicahistoryBLL = null;
                    hcMedicahistoryBLL = new HcMedicahistoryBLL();
                    return hcMedicahistoryBLL.SaveHcMedicahistoryInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcMedicahistoryInfo:
                    hcMedicahistoryBLL = new HcMedicahistoryBLL();
                    return hcMedicahistoryBLL.UpdateHcMedicahistoryInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcMedicahistoryInfoById:
                    hcMedicahistoryBLL = new HcMedicahistoryBLL();
                    return hcMedicahistoryBLL.DeleteHcMedicahistoryInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcMedicahistoryRecord:
                    hcMedicahistoryBLL = new HcMedicahistoryBLL();
                    return hcMedicahistoryBLL.GetAllHcMedicahistoryRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcMedicahistoryRecordById:
                    hcMedicahistoryBLL = new HcMedicahistoryBLL();
                    return hcMedicahistoryBLL.GetSingleHcMedicahistoryRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Organization
                case HCareTaks.AG_SaveHcOrganizationInfo:
                    HcOrganizationBLL hcOrganizationBLL = null;
                    hcOrganizationBLL = new HcOrganizationBLL();
                    return hcOrganizationBLL.SaveHcOrganizationInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcOrganizationInfo:
                    hcOrganizationBLL = new HcOrganizationBLL();
                    return hcOrganizationBLL.UpdateHcOrganizationInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcOrganizationInfoById:
                    hcOrganizationBLL = new HcOrganizationBLL();
                    return hcOrganizationBLL.DeleteHcOrganizationInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcOrganizationRecord:
                    hcOrganizationBLL = new HcOrganizationBLL();
                    return hcOrganizationBLL.GetAllHcOrganizationRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcOrganizationRecordById:
                    hcOrganizationBLL = new HcOrganizationBLL();
                    return hcOrganizationBLL.GetSingleHcOrganizationRecordById(param);
                    break;
                #endregion
                    //21-1-2021
                #region Auto Generated - HC_About
                case HCareTaks.AG_SaveHcAboutInfo:
                    HcAboutBLL hcAboutBLL = null;
                    hcAboutBLL = new HcAboutBLL();
                    return hcAboutBLL.SaveHcAboutInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcAboutInfo:
                    hcAboutBLL = new HcAboutBLL();
                    return hcAboutBLL.UpdateHcAboutInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcAboutInfoById:
                    hcAboutBLL = new HcAboutBLL();
                    return hcAboutBLL.DeleteHcAboutInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcAboutRecord:
                    hcAboutBLL = new HcAboutBLL();
                    return hcAboutBLL.GetAllHcAboutRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcAboutRecordById:
                    hcAboutBLL = new HcAboutBLL();
                    return hcAboutBLL.GetSingleHcAboutRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Blog
                case HCareTaks.AG_SaveHcBlogInfo:
                    HcBlogBLL hcBlogBLL = null;
                    hcBlogBLL = new HcBlogBLL();
                    return hcBlogBLL.SaveHcBlogInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcBlogInfo:
                    hcBlogBLL = new HcBlogBLL();
                    return hcBlogBLL.UpdateHcBlogInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcBlogInfoById:
                    hcBlogBLL = new HcBlogBLL();
                    return hcBlogBLL.DeleteHcBlogInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcBlogRecord:
                    hcBlogBLL = new HcBlogBLL();
                    return hcBlogBLL.GetAllHcBlogRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcBlogRecordById:
                    hcBlogBLL = new HcBlogBLL();
                    return hcBlogBLL.GetSingleHcBlogRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_GuideDetails
                case HCareTaks.AG_SaveHcGuidedetailsInfo:
                    HcGuidedetailsBLL hcGuidedetailsBLL = null;
                    hcGuidedetailsBLL = new HcGuidedetailsBLL();
                    return hcGuidedetailsBLL.SaveHcGuidedetailsInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcGuidedetailsInfo:
                    hcGuidedetailsBLL = new HcGuidedetailsBLL();
                    return hcGuidedetailsBLL.UpdateHcGuidedetailsInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcGuidedetailsInfoById:
                    hcGuidedetailsBLL = new HcGuidedetailsBLL();
                    return hcGuidedetailsBLL.DeleteHcGuidedetailsInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcGuidedetailsRecord:
                    hcGuidedetailsBLL = new HcGuidedetailsBLL();
                    return hcGuidedetailsBLL.GetAllHcGuidedetailsRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcGuidedetailsRecordById:
                    hcGuidedetailsBLL = new HcGuidedetailsBLL();
                    return hcGuidedetailsBLL.GetSingleHcGuidedetailsRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_guideMaster
                case HCareTaks.AG_SaveHcGuidemasterInfo:
                    HcGuidemasterBLL hcGuidemasterBLL = null;
                    hcGuidemasterBLL = new HcGuidemasterBLL();
                    return hcGuidemasterBLL.SaveHcGuidemasterInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcGuidemasterInfo:
                    hcGuidemasterBLL = new HcGuidemasterBLL();
                    return hcGuidemasterBLL.UpdateHcGuidemasterInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcGuidemasterInfoById:
                    hcGuidemasterBLL = new HcGuidemasterBLL();
                    return hcGuidemasterBLL.DeleteHcGuidemasterInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcGuidemasterRecord:
                    hcGuidemasterBLL = new HcGuidemasterBLL();
                    return hcGuidemasterBLL.GetAllHcGuidemasterRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcGuidemasterRecordById:
                    hcGuidemasterBLL = new HcGuidemasterBLL();
                    return hcGuidemasterBLL.GetSingleHcGuidemasterRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_Offers
                case HCareTaks.AG_SaveHcOffersInfo:
                    HcOffersBLL hcOffersBLL = null;
                    hcOffersBLL = new HcOffersBLL();
                    return hcOffersBLL.SaveHcOffersInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcOffersInfo:
                    hcOffersBLL = new HcOffersBLL();
                    return hcOffersBLL.UpdateHcOffersInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcOffersInfoById:
                    hcOffersBLL = new HcOffersBLL();
                    return hcOffersBLL.DeleteHcOffersInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcOffersRecord:
                    hcOffersBLL = new HcOffersBLL();
                    return hcOffersBLL.GetAllHcOffersRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcOffersRecordById:
                    hcOffersBLL = new HcOffersBLL();
                    return hcOffersBLL.GetSingleHcOffersRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_PackageDetails
                case HCareTaks.AG_SaveHcPackagedetailsInfo:
                    HcPackagedetailsBLL hcPackagedetailsBLL = null;
                    hcPackagedetailsBLL = new HcPackagedetailsBLL();
                    return hcPackagedetailsBLL.SaveHcPackagedetailsInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcPackagedetailsInfo:
                    hcPackagedetailsBLL = new HcPackagedetailsBLL();
                    return hcPackagedetailsBLL.UpdateHcPackagedetailsInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcPackagedetailsInfoById:
                    hcPackagedetailsBLL = new HcPackagedetailsBLL();
                    return hcPackagedetailsBLL.DeleteHcPackagedetailsInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcPackagedetailsRecord:
                    hcPackagedetailsBLL = new HcPackagedetailsBLL();
                    return hcPackagedetailsBLL.GetAllHcPackagedetailsRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcPackagedetailsRecordById:
                    hcPackagedetailsBLL = new HcPackagedetailsBLL();
                    return hcPackagedetailsBLL.GetSingleHcPackagedetailsRecordById(param);
                    break;
                #endregion

                #region Auto Generated - HC_PackageMaster
                case HCareTaks.AG_SaveHcPackagemasterInfo:
                    HcPackagemasterBLL hcPackagemasterBLL = null;
                    hcPackagemasterBLL = new HcPackagemasterBLL();
                    return hcPackagemasterBLL.SaveHcPackagemasterInfo(param);
                    break;
                case HCareTaks.AG_UpdateHcPackagemasterInfo:
                    hcPackagemasterBLL = new HcPackagemasterBLL();
                    return hcPackagemasterBLL.UpdateHcPackagemasterInfo(param);
                    break;
                case HCareTaks.AG_DeleteHcPackagemasterInfoById:
                    hcPackagemasterBLL = new HcPackagemasterBLL();
                    return hcPackagemasterBLL.DeleteHcPackagemasterInfoById(param);
                    break;
                case HCareTaks.AG_GetAllHcPackagemasterRecord:
                    hcPackagemasterBLL = new HcPackagemasterBLL();
                    return hcPackagemasterBLL.GetAllHcPackagemasterRecord(param);
                    break;
                case HCareTaks.AG_GetSingleHcPackagemasterRecordById:
                    hcPackagemasterBLL = new HcPackagemasterBLL();
                    return hcPackagemasterBLL.GetSingleHcPackagemasterRecordById(param);
                    break;
                #endregion






                default:
                    break;
            }
            return null;
        }
    }
}
