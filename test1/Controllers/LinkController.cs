using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{
    public class LinkController : Controller
    {
        private DammioMVCEntities db = new DammioMVCEntities();

        // GET: Link
        public ActionResult Index(string searchString, int categoryID = 0)
        {
            //return View(db.Links.ToList());

            // Sửa phương thức để thiết lập mục tìm kiếm: 
            var links = from l in db.Links // lấy toàn bộ liên kết
                        select l;
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                links = links.Where(s => s.LinkName.Contains(searchString)); //lọc theo chuỗi tìm kiếm, sử dụng cú pháp lambda (biểu thức LINQ)
            }
            return View(links); //trả về kết quả

            // thêm mục tìm kiếm theo danh mục : 
            //1. Tạo danh sách danh mục để hiển thị ở giao diện View thông qua DropDownList
            //var categories = from c in db.Categories select c;
            //ViewBag.categoryID = new SelectList(categories, "CategoryID", "CategoryName"); // danh sách Category

            ////2. Tạo câu truy vấn kết 2 bảng Link, Category bằng mệnh đề join
            //var links = from l in db.Links
            //            join c in db.Categories on l.CategoryID equals c.CategoryID
            //            select new { l.LinkID, l.LinkName, l.LinkDescription, l.CategoryID, c.CategoryName };
            ////3. Tìm kiếm chuỗi truy vấn
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    links = links.Where(s => s.LinkName.Contains(searchString));
            //}
            ////4. Tìm kiếm theo CategoryID
            //if (categoryID != 0)
            //{
            //    links = links.Where(x => x.CategoryID == categoryID);
            //}

            ////5. Chuyển đổi kết quả từ var sang danh sách List<Link>
            //List<Link> listLinks = new List<Link>();
            //foreach (var item in links)
            //{
            //    Link temp = new Link();
            //    temp.CategoryID = item.CategoryID;
            //    temp.CategoryName = item.CategoryName;
            //    temp.LinkDescription = item.LinkDescription;
            //    temp.LinkID = item.LinkID;
            //    temp.LinkName = item.LinkName;
            //    listLinks.Add(temp);
            //}

            //return View(listLinks);

        }

        // GET: Link/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // GET: Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LinkID,LinkName,LinkDescription,CategoryID")] Link link)
        {
            if (ModelState.IsValid)
            {
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(link);
        }

        // GET: Link/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);  // Tìm liên kết theo id tương ứng
            if (link == null)
                if (link == null)
            {
                return HttpNotFound();   // Nếu khôgng tìm thấy hiển thị kết quả ko tìm thấy
            }
            return View(link);   // nếu tìm thấy hiển thị nội dung
        }

        // POST: Link/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]     // phương thức này dùng thuộc tính httpPost , dũ liệu cập nhật chỉ dùng Post để bảo mật 
        [ValidateAntiForgeryToken]   // kiểm chứng token phải khớp với bên edit.cshtml
        public ActionResult Edit([Bind(Include = "LinkID,LinkName,LinkDescription,CategoryID")] Link link)    // thuộc tính bind là cơ chế bảo mật đề phòng đẩy dl nhiều quá mức
        {
            if (ModelState.IsValid)
            {
                db.Entry(link).State = EntityState.Modified;   // Chọn trạng thái là thay đổi database
                db.SaveChanges();                    // Lưu lại
                return RedirectToAction("Index");   // sau khi cập nhật thì quay về trang chủ
            }
            return View(link);
        }

        // GET: Link/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Link link = db.Links.Find(id);
            if (link == null)
            {
                return HttpNotFound();
            }
            return View(link);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Link link = db.Links.Find(id);
            db.Links.Remove(link);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
