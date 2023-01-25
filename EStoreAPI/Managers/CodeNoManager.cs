using ClosedXML.Excel;
using EStoreAPI.Models;
using EStoreAPI.ViewModels;
using System.IO;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using EStoreAPI.Repositories;

namespace EStoreAPI.Managers
{
    public class CodeNoManager
    {
        public async Task<string> GenerateCodeNo()
        {
            List<TbCode> codelist = new List<TbCode>();

            int count = 100001;
            int max = 101000;
            while (count <= max)
            {
                TbCode model = new TbCode()
                {
                    Codeno = count.ToString(),
                    Isredeem = false
                };

                codelist.Add(model);
                count++;
            }

            DataTable dt = new DataTable();
            dt.TableName = "Data Report";
            dt.Columns.Add("Codeno", typeof(string));
            dt.Columns.Add("Isredeem", typeof(bool));

            Shuffle(codelist);
            try
            {
                using (EstoreContext ctx = new EstoreContext())
                {
                    CodeNoRepository cnrepo = new CodeNoRepository(ctx);
                    foreach (var c in codelist)
                    {
                        await cnrepo.Add(c);
                    }
                }
                return "Success";
            }
            catch(Exception ex)
            {
                return "Fail";
            }            
                
            //foreach (var d in codelist)
            //{
            //    dt.Rows.Add(
            //        d.Codeno,
            //        d.Isredeem
            //        );
            //}
            //dt.AcceptChanges();

            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt);

            //    using (MemoryStream stream = new MemoryStream())
            //    {
            //        wb.SaveAs(stream);
            //        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ticket-list" + ".xlsx");
            //    }
            //}            
        }

        private void Shuffle<TbCode>(List<TbCode> array)
        {
            var _random = new Random();
            int n = array.Count;
            for (int i = 0; i < (n - 1); i++)
            {
                int r = i + _random.Next(n - i);
                TbCode t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
