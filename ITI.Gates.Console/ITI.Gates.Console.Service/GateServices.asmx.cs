using ITI.Gates.Console.DAL.DAL;
using ITI.Gates.Console.DAL.Helper;
using ITI.Gates.Console.DAL.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services;

namespace ITI.Gates.Console.Service
{
    /// <summary>
    /// Summary description for GateServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GateServices : System.Web.Services.WebService
    {
        #region Fields
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private ContCardDAL contCardDAL = new ContCardDAL();
        #endregion

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod]
        public bool Login(string userId, string password)
        {
            try
            {
                string hashed = PhpCompatible.Md5Hash(password);
                return AppPrincipal.Login(userId, hashed);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Login -> Message: {0}", ex.Message);
                log.ErrorFormat("Login -> StackTrace: {0}", ex.StackTrace);
                return false;
            }

        }

        [WebMethod]
        public string CheckKendaraan(long id)
        {
            try
            {
                ContCard contCard = new ContCard();
                contCard = contCardDAL.FillContCardByContCardId(id);
                return contCard.ContCardID > 0 ? Converter.ConvertToXML(contCard) : string.Empty;

            }
            catch (Exception ex)
            {
                log.ErrorFormat("FillContCardByContCardId -> Parameter: id={0}", id);
                log.ErrorFormat("FillContCardByContCardId -> Message: {0}", ex.Message);
                log.ErrorFormat("FillContCardByContCardId -> StackTrace: {0}", ex.StackTrace);
                return "Error: Tidak dapat memproses kartu: " + id;
            }

        }

        [WebMethod]
        public bool UpdateContCardGateIn(long id, string location)
        {
            try
            {

                return contCardDAL.UpdateContCardGateIn(id, location);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("UpdateContCardGateIn -> Parameter: id={0},location={1}", id, location);
                log.ErrorFormat("UpdateContCardGateIn -> Message: {0}", ex.Message);
                log.ErrorFormat("UpdateContCardGateIn -> StackTrace: {0}", ex.StackTrace);
                return false;
            }
        }

        [WebMethod]
        public bool UpdateContInOutGateIn(long id, string location)
        {
            try
            {

                return contCardDAL.UpdateContCardInOutGateIn(id, location);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("UpdateContInOutGateIn -> Parameter: id={0},location={1}", id, location);
                log.ErrorFormat("UpdateContInOutGateIn -> Message: {0}", ex.Message);
                log.ErrorFormat("UpdateContInOutGateIn -> StackTrace: {0}", ex.StackTrace);
                return false;
            }
        }
        [WebMethod]
        public bool UpdateContCardGateOut(long id, string location)
        {
            try
            {

                return contCardDAL.UpdateContCardGateOut(id, location);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("UpdateContCardGateOut -> Parameter: id={0},location={1}", id, location);
                log.ErrorFormat("UpdateContCardGateOut -> Message: {0}", ex.Message);
                log.ErrorFormat("UpdateContCardGateOut -> StackTrace: {0}", ex.StackTrace);
                return false;
            }
        }
        [WebMethod]
        public bool UpdateContInOutGateOut(long id, string location)
        {
            try
            {

                return contCardDAL.UpdateContCardInOutGateOut(id, location);

            }
            catch (Exception ex)
            {
                log.ErrorFormat("UpdateContInOutGateOut -> Parameter: id={0},location={1}", id, location);
                log.ErrorFormat("UpdateContInOutGateOut -> Message: {0}", ex.Message);
                log.ErrorFormat("UpdateContInOutGateOut -> StackTrace: {0}", ex.StackTrace);
                return false;
            }
        }
    }
}
