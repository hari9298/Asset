
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using System.Linq;

using Microsoft.EntityFrameworkCore;

using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class CommonMapper
    {
        //TUserMaster destinationUsr ;
    

        public static CommonList ConvertToCommonModel(this TCompanyMaster Common)
        {
            return new CommonList
            {
                ItemID = Common.CmId,
                ItemName = Common.CmName
              

            };
        }

        public static List<CommonList> ConvertToCommonModelList(this List<TCompanyMaster> Commons)
        {
            return Commons.Select(Common => Common.ConvertToCommonModel()).ToList();
        }

        public static TCompanyMaster ConvertToCommonEntity(this CommonList Common)
        {
            return new TCompanyMaster
            {
                CmId = Convert.ToInt32(Common.ItemID),
                CmName = Common.ItemName    
               
            };
        }
        public static List<TCompanyMaster> ConvertToCommonEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToCommonEntity()).ToList();

        }
        
        public static CommonList ConvertToQuestionModel(this TCommonListMaster Common)
        {
            return new CommonList
            {
                ItemID = Common.ClId,
                ItemName = Common.ClListName
              

            };
        }

        public static List<CommonList> ConvertToQuestionModelList(this List<TCommonListMaster> Commons)
        {
            return Commons.Select(Common => Common.ConvertToQuestionModel()).ToList();
        }

        public static TCommonListMaster ConvertToQuestionEntity(this CommonList Common)
        {
            return new TCommonListMaster
            {
                ClId = Convert.ToInt32(Common.ItemID),
                ClListName = Common.ItemName    
               
            };
        }
        public static List<TCommonListMaster> ConvertToQuestionEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToQuestionEntity()).ToList();

        }


        //public static CommonList ConvertToGroupModel(this TGroupMaster Common)
        //{
        //    return new CommonList
        //    {
        //        ItemID = Common.GmId,
        //        ItemName = Common.GmName


        //    };
        //}

        ////public static List<CommonList> ConvertToGroupList(this List<TGroupMaster> Commons)
        ////{
        ////    return Commons.Select(Common => Common.ConvertToGroupModel()).ToList();
        ////}
 
    //Tbldeliveryrank

        public static CommonList ConvertToDeliveryRankModel(this Tbldeliveryrank Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.DeliveryRankName
              

            };
        }

        public static List<CommonList> ConvertToDeliveryRankModelList(this List<Tbldeliveryrank> Commons)
        {
            return Commons.Select(Common => Common.ConvertToDeliveryRankModel()).ToList();
        }

        public static Tbldeliveryrank ConvertToDeliveryRankEntity(this CommonList Common)
        {
            return new Tbldeliveryrank
            {
                Id = Convert.ToInt32(Common.ItemID),
                DeliveryRankName = Common.ItemName    
               
            };
        }
        public static List<Tbldeliveryrank> ConvertToDeliveryRankEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToDeliveryRankEntity()).ToList();

        }

   //Tblnomsubcycle

        public static CommonList ConvertToNomSubCycleModel(this Tblnomsubcycle Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.NomSubCname
              

            };
        }

        public static List<CommonList> ConvertToNomSubCycleModelList(this List<Tblnomsubcycle> Commons)
        {
            return Commons.Select(Common => Common.ConvertToNomSubCycleModel()).ToList();
        }

        public static Tblnomsubcycle ConvertToNomSubCycleEntity(this CommonList Common)
        {
            return new Tblnomsubcycle
            {
                Id = Convert.ToInt32(Common.ItemID),
                NomSubCname = Common.ItemName    
               
            };
        }
        public static List<Tblnomsubcycle> ConvertToNomSubCycleEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToNomSubCycleEntity()).ToList();

        }

     //Tblpkgid

        public static CommonList ConvertToPkgIdModel(this Tblpkgid Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.PkgId
              

            };
        }

        public static List<CommonList> ConvertToPkgIdModelList(this List<Tblpkgid> Commons)
        {
            return Commons.Select(Common => Common.ConvertToPkgIdModel()).ToList();
        }

        public static Tblpkgid ConvertToPkgIdEntity(this CommonList Common)
        {
            return new Tblpkgid
            {
                Id = Convert.ToInt32(Common.ItemID),
                PkgId = Common.ItemName    
               
            };
        }
        public static List<Tblpkgid> ConvertToPkgIdEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToPkgIdEntity()).ToList();

        }

    //Tblratescheduled

        public static CommonList ConvertToRateScheduledModel(this Tblratescheduled Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.RateName
              

            };
        }

        public static List<CommonList> ConvertToRateScheduledModelList(this List<Tblratescheduled> Commons)
        {
            return Commons.Select(Common => Common.ConvertToRateScheduledModel()).ToList();
        }

        public static Tblratescheduled ConvertToRateScheduledEntity(this CommonList Common)
        {
            return new Tblratescheduled
            {
                Id = Convert.ToInt32(Common.ItemID),
                RateName = Common.ItemName    
               
            };
        }
        public static List<Tblratescheduled> ConvertToRateScheduledEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToRateScheduledEntity()).ToList();

        }

    //Tblreceiptlocname

        public static CommonList ConvertToReceiptLocNameModel(this Tblreceiptlocname Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.ReceiptLocName
              

            };
        }

        public static List<CommonList> ConvertToReceiptLocNameModelList(this List<Tblreceiptlocname> Commons)
        {
            return Commons.Select(Common => Common.ConvertToReceiptLocNameModel()).ToList();
        }

        public static Tblreceiptlocname ConvertToReceiptLocNameEntity(this CommonList Common)
        {
            return new Tblreceiptlocname
            {
                Id = Convert.ToInt32(Common.ItemID),
                ReceiptLocName = Common.ItemName    
               
            };
        }
        public static List<Tblreceiptlocname> ConvertToReceiptLocNameEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToReceiptLocNameEntity()).ToList();

        }

    //Tblreceiptquantity

        public static CommonList ConvertToReceiptQuantityModel(this Tblreceiptquantity Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.ReceiptQuantityName
              

            };
        }

        public static List<CommonList> ConvertToReceiptQuantityModelList(this List<Tblreceiptquantity> Commons)
        {
            return Commons.Select(Common => Common.ConvertToReceiptQuantityModel()).ToList();
        }

        public static Tblreceiptquantity ConvertToReceiptQuantityEntity(this CommonList Common)
        {
            return new Tblreceiptquantity
            {
                Id = Convert.ToInt32(Common.ItemID),
                ReceiptQuantityName = Common.ItemName    
               
            };
        }
        public static List<Tblreceiptquantity> ConvertToReceiptQuantityEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToReceiptQuantityEntity()).ToList();

        }

    //Tblreceiptrank

        public static CommonList ConvertToReceiptRankModel(this Tblreceiptrank Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.ReceiptRankName
              

            };
        }

        public static List<CommonList> ConvertToReceiptRankModelList(this List<Tblreceiptrank> Commons)
        {
            return Commons.Select(Common => Common.ConvertToReceiptRankModel()).ToList();
        }

        public static Tblreceiptrank ConvertToReceiptRankEntity(this CommonList Common)
        {
            return new Tblreceiptrank
            {
                Id = Convert.ToInt32(Common.ItemID),
                ReceiptRankName = Common.ItemName    
               
            };
        }
        public static List<Tblreceiptrank> ConvertToReceiptRankEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToReceiptRankEntity()).ToList();

        }

    //Tblsvcreqkey

        public static CommonList ConvertToSvcReqKeyModel(this Tblsvcreqkey Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.SvcReqKeyName
              

            };
        }

        public static List<CommonList> ConvertToSvcReqKeyModelList(this List<Tblsvcreqkey> Commons)
        {
            return Commons.Select(Common => Common.ConvertToSvcReqKeyModel()).ToList();
        }

        public static Tblsvcreqkey ConvertToSvcReqKeyEntity(this CommonList Common)
        {
            return new Tblsvcreqkey
            {
                Id = Convert.ToInt32(Common.ItemID),
                SvcReqKeyName = Common.ItemName    
               
            };
        }
        public static List<Tblsvcreqkey> ConvertToSvcReqKeyEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToSvcReqKeyEntity()).ToList();

        }

    //Tbltransactioninfo

        public static CommonList ConvertToTransactionInfoModel(this Tbltransactioninfo Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.TransactionInfoName
              

            };
        }

        public static List<CommonList> ConvertToTransactionInfoModelList(this List<Tbltransactioninfo> Commons)
        {
            return Commons.Select(Common => Common.ConvertToTransactionInfoModel()).ToList();
        }

        public static Tbltransactioninfo ConvertToTransactionInfoEntity(this CommonList Common)
        {
            return new Tbltransactioninfo
            {
                Id = Convert.ToInt32(Common.ItemID),
                TransactionInfoName = Common.ItemName    
               
            };
        }
        public static List<Tbltransactioninfo> ConvertToTransactionInfoEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToTransactionInfoEntity()).ToList();

        }

    //Tblupk

        public static CommonList ConvertToUpkModel(this Tblupk Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.UpKname
              

            };
        }

        public static List<CommonList> ConvertToUpkModelList(this List<Tblupk> Commons)
        {
            return Commons.Select(Common => Common.ConvertToUpkModel()).ToList();
        }

        public static Tblupk ConvertToUpkEntity(this CommonList Common)
        {
            return new Tblupk
            {
                Id = Convert.ToInt32(Common.ItemID),
                UpKname = Common.ItemName    
               
            };
        }
        public static List<Tblupk> ConvertToUpkEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToUpkEntity()).ToList();

        }

    
    //Tblupname

        public static CommonList ConvertToUpNameModel(this Tblupname Common)
        {
            return new CommonList
            {
                ItemID = Common.Id,
                ItemName = Common.UpName
              

            };
        }

        public static List<CommonList> ConvertToUpNameModelList(this List<Tblupname> Commons)
        {
            return Commons.Select(Common => Common.ConvertToUpNameModel()).ToList();
        }

        public static Tblupname ConvertToUpNameEntity(this CommonList Common)
        {
            return new Tblupname
            {
                Id = Convert.ToInt32(Common.ItemID),
                UpName = Common.ItemName    
               
            };
        }
        public static List<Tblupname> ConvertToUpNameEntityList(this List<CommonList> Commons)
        {
            return Commons.Select(usr => usr.ConvertToUpNameEntity()).ToList();

        }
    }


}