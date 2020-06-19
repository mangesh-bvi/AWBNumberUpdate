﻿using AWBNumberUpdate.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Linq;
using AWBNumberUpdate.Service;

namespace AWBNumberUpdate
{
    class Program
    {
        public static int delaytime = 0;

        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            delaytime = Convert.ToInt32(config.GetSection("MySettings").GetSection("IntervalInMinutes").Value);

            Thread _Individualprocessthread = new Thread(new ThreadStart(InvokeMethod));
            _Individualprocessthread.Start();
        }
        public static void InvokeMethod()
        {
            while (true)
            {
               GetConnectionStrings();
                //GetdataFromMySQL();
                Thread.Sleep(delaytime);
            }
        }

        public static void GetConnectionStrings()
        {
            string ServerName = string.Empty;
            string ServerCredentailsUsername = string.Empty;
            string ServerCredentailsPassword = string.Empty;
            string DBConnection = string.Empty;


            try
            {
                DataTable dt = new DataTable();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var constr = config.GetSection("ConnectionStrings").GetSection("HomeShop").Value;
                MySqlConnection con = new MySqlConnection(constr);
                MySqlCommand cmd = new MySqlCommand("SP_HSGetAllConnectionstrings", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        ServerName = Convert.ToString(dr["ServerName"]);
                        ServerCredentailsUsername = Convert.ToString(dr["ServerCredentailsUsername"]);
                        ServerCredentailsPassword = Convert.ToString(dr["ServerCredentailsPassword"]);
                        DBConnection = Convert.ToString(dr["DBConnection"]);

                        string ConString = "Data Source = " + ServerName + " ; port = " + 3306 + "; Initial Catalog = " + DBConnection + " ; User Id = " + ServerCredentailsUsername + "; password = " + ServerCredentailsPassword + "";
                        GetdataFromMySQL(ConString);
                    }
                }
            }
            catch
            {


            }
            finally
            {

                GC.Collect();
            }


        }


        public static void GetdataFromMySQL(string ConString)
        {
            string apiResponse = string.Empty;
            string apiGenPickupRes = string.Empty;
            string apiGenMenifestRes = string.Empty;

            AWBResponce awbResponce = new AWBResponce();
            PickupResponce pickupResponce = new PickupResponce();
            ManifestResponce manifestResponce = new ManifestResponce();

            MySqlConnection con = null;
            try
            {
                DataSet ds = new DataSet();
                AWBRequest objdetails = new AWBRequest();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var constr = config.GetSection("ConnectionStrings").GetSection("HomeShop").Value;
                string ClientAPIURL = config.GetSection("MySettings").GetSection("ClientAPIURL").Value;
                con = new MySqlConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("SP_PHYGetOrderdetailForAWB", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds != null && ds.Tables[0] != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds != null && ds.Tables[1] != null)
                        {
                            objdetails = new AWBRequest()
                            {
                                pickup_postcode = ds.Tables[1].Rows[0]["pickup_postcode"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[1].Rows[0]["pickup_postcode"]),
                                delivery_postcode = ds.Tables[1].Rows[0]["delivery_postcode"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[1].Rows[0]["delivery_postcode"]),
                                weight = 1,
                                orderDetails = new orderDetails()
                            };

                        }

                        orderDetails orderDetails = new orderDetails
                        {
                            Id = ds.Tables[0].Rows[i]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]),
                            order_id = ds.Tables[0].Rows[i]["InvoiceNo"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["InvoiceNo"]),
                            order_date = ds.Tables[0].Rows[i]["Date"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Date"]),
                            billing_customer_name = ds.Tables[0].Rows[i]["CustomerName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CustomerName"]),
                            billing_address = ds.Tables[0].Rows[i]["ShippingAddress"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ShippingAddress"]),
                            billing_city = ds.Tables[0].Rows[i]["City"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["City"]),
                            billing_pincode = ds.Tables[0].Rows[i]["delivery_postcode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["delivery_postcode"]),
                            billing_state = ds.Tables[0].Rows[i]["State"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["State"]),
                            billing_country = ds.Tables[0].Rows[i]["Country"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Country"]),
                            //billing_email = ds.Tables[0].Rows[i]["EmailID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]),
                            billing_phone = ds.Tables[0].Rows[i]["MobileNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]),
                            shipping_customer_name = ds.Tables[0].Rows[i]["CustomerName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["CustomerName"]),
                            shipping_address = ds.Tables[0].Rows[i]["ShippingAddress"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["ShippingAddress"]),
                            shipping_city = ds.Tables[0].Rows[i]["City"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["City"]),
                            shipping_pincode = ds.Tables[0].Rows[i]["delivery_postcode"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["delivery_postcode"]),
                            shipping_country = ds.Tables[0].Rows[i]["Country"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["Country"]),
                            shipping_state = ds.Tables[0].Rows[i]["State"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["State"]),
                            //shipping_email = ds.Tables[0].Rows[i]["EmailID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]),
                            shipping_phone = ds.Tables[0].Rows[i]["MobileNumber"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[0].Rows[i]["MobileNumber"]),
                            shipping_is_billing = true,
                            billing_email = "naruto@uzumaki.com",
                            shipping_email = "naruto@uzumaki.com",
                            payment_method = "Prepaid",
                            pickup_location = "Test",
                            channel_id = "633828",
                            billing_last_name = "",
                            billing_address_2 = "",
                            billing_alternate_phone = "",
                            shipping_last_name = "",
                            shipping_address_2 = "",
                            sub_total = 20,
                            length = 10,
                            breadth = 10,
                            height = 2,
                            weight = 2,
                            StoreDelivery = Convert.ToBoolean(ds.Tables[0].Rows[i]["StoreDelivery"]),
                            TenantId = ds.Tables[0].Rows[i]["TenantId"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["TenantId"]),
                            order_items = new List<order_items>()
                        };
                        List<order_items> listobj = new List<order_items>();

                        string ItemIDs = "";
                        for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                        {
                            if (Convert.ToInt32(ds.Tables[2].Rows[j]["OrderID"]) == Convert.ToInt32(orderDetails.Id))
                            {
                                order_items objorder_Items = new order_items()
                                {
                                    OrderItemID = ds.Tables[2].Rows[j]["ID"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[2].Rows[j]["ID"]),
                                    name = ds.Tables[2].Rows[j]["ItemName"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[2].Rows[j]["ItemName"]),
                                    sku = ds.Tables[2].Rows[j]["ItemID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[2].Rows[j]["ItemID"]),
                                    units = ds.Tables[2].Rows[j]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(ds.Tables[2].Rows[j]["Quantity"]),
                                    selling_price = ds.Tables[2].Rows[j]["ItemPrice"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[2].Rows[j]["ItemPrice"])
                                };
                                listobj.Add(objorder_Items);
                                ItemIDs += ds.Tables[2].Rows[j]["ID"] == DBNull.Value ? string.Empty : Convert.ToString(ds.Tables[2].Rows[j]["ID"]) + ",";

                            }

                        }
                        orderDetails.order_items = listobj;
                        ItemIDs = ItemIDs.TrimEnd(',');
                        objdetails.orderDetails = orderDetails;
                        string apiReq = JsonConvert.SerializeObject(objdetails);
                        apiResponse = CommonService.SendApiRequest(ClientAPIURL + "/api/ShoppingBag/GetCouriersPartnerAndAWBCode", apiReq);
                        awbResponce = JsonConvert.DeserializeObject<AWBResponce>(apiResponse);

                        if (awbResponce.data.awb_code != "" && awbResponce.data.courier_name != "")
                        {
                          InsertCourierResponse(orderDetails.Id, ItemIDs, awbResponce.data.awb_code, awbResponce.data.courier_company_id, awbResponce.data.courier_name, awbResponce.data.order_id, awbResponce.data.shipment_id, ConString);

                            if (awbResponce != null)
                            {
                                if (awbResponce.data != null)
                                {
                                    if (awbResponce.data.shipment_id != null)
                                    {
                                        PickupManifestRequest pickupManifestRequest = new PickupManifestRequest()
                                        {
                                            shipmentId = new List<int> {
                                                Convert.ToInt32(awbResponce.data.shipment_id)  
                                            }
                                        };

                                        try
                                        {
                                            string apiGenPickupReq = JsonConvert.SerializeObject(pickupManifestRequest);
                                            apiGenPickupRes = CommonService.SendApiRequest(ClientAPIURL + "/api​/ShoppingBag​/GeneratePickup", apiGenPickupReq);
                                            pickupResponce = JsonConvert.DeserializeObject<PickupResponce>(apiGenPickupRes);
                                            if (pickupResponce.response.pickupTokenNumber != "")
                                            {
                                                UpdateGeneratePickupManifest(orderDetails.Id, orderDetails.TenantId, orderDetails.Id, "Pickup", ConString);
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                        try
                                        {
                                            string apiGenMenifestReq = JsonConvert.SerializeObject(pickupManifestRequest);
                                            apiGenMenifestRes = CommonService.SendApiRequest(ClientAPIURL + "/api/ShoppingBag/GenerateManifest", apiGenMenifestReq);
                                            manifestResponce = JsonConvert.DeserializeObject<ManifestResponce>(apiGenMenifestRes);
                                            if (manifestResponce.status == "1")
                                            {
                                                UpdateGeneratePickupManifest(orderDetails.Id, orderDetails.TenantId, orderDetails.Id, "Manifest", ConString);
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (orderDetails.StoreDelivery == true)
                            {
                                 AddStoreResponse(orderDetails.Id, ItemIDs, orderDetails.TenantId, true, ConString);
                            }
                            else
                            {
                              AddStoreResponse(orderDetails.Id, ItemIDs, orderDetails.TenantId, false, ConString);
                            }

                        }

                    }

                }

            }
            catch (Exception)
            {

            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
                GC.Collect();
            }
        }


        public static void AddStoreResponse(int ID, string ItemIDs, int TenantId, bool storeFlag,string ConString)
        {

            try
            {
                DataTable dt = new DataTable();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var constr = config.GetSection("ConnectionStrings").GetSection("HomeShop").Value;
                MySqlConnection con = new MySqlConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("SP_PHYUpdateStoreResponce", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@_id", ID);
                cmd.Parameters.AddWithValue("@item_IDs", ItemIDs);
                cmd.Parameters.AddWithValue("@_TenantID", TenantId);
                cmd.Parameters.AddWithValue("@_storeFlag", storeFlag);
                cmd.Parameters.AddWithValue("@_awbCode", "");
                //cmd.Parameters.AddWithValue("@_courierCompnyName", courierCompnyName);



                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            {

            }
            finally
            {
                GC.Collect();
            }

        }

        public static void InsertCourierResponse(int OrderId, string ItemIDs, string awbCode, string courierCompnyId, string courierCompnyName, string courierOrderId, string courierShipmentId,string ConString)
        {

            try
            {
                DataTable dt = new DataTable();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var constr = config.GetSection("ConnectionStrings").GetSection("HomeShop").Value;
                MySqlConnection con = new MySqlConnection(ConString);
               
                MySqlCommand cmd = new MySqlCommand("SP_PHYInsertAWBDetails", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@order_ID", OrderId);
                cmd.Parameters.AddWithValue("@item_IDs", ItemIDs);
                cmd.Parameters.AddWithValue("@_Awb_code", awbCode);
                cmd.Parameters.AddWithValue("@_CourierPartnerID", courierCompnyId);
                cmd.Parameters.AddWithValue("@_CourierPartner", courierCompnyName);
                cmd.Parameters.AddWithValue("@_CourierPartnerOrderID", courierOrderId);
                cmd.Parameters.AddWithValue("@_CourierPartnerShipmentID", courierShipmentId);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            {

            }
            finally
            {
                GC.Collect();
            }

        }


        public static void UpdateGeneratePickupManifest(int orderID, int tenantID, int userID, string status,string ConString)
        {
           
            try
            {
                DataTable dt = new DataTable();
                IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
                var constr = config.GetSection("ConnectionStrings").GetSection("HomeShop").Value;
                MySqlConnection con = new MySqlConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("SP_PHYUpdateflagPickupManifest", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@order_ID", orderID);
                cmd.Parameters.AddWithValue("@tenant_ID", tenantID);
                cmd.Parameters.AddWithValue("@user_ID", userID);
                cmd.Parameters.AddWithValue("@_status", status);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            {

            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
