using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyApi.Authentication;
using PharmacyApi.Models;
using PharmacyApi.ViewModel;
using PharmacyApi.Mappers;

namespace PharmacyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetDrug()
        {
            var orders = await _context.Order.ToListAsync();
            return orders;
        }

        [Route("PutOrderByPharmacyId/{orderId}")]
        public ActionResult<OrderVM> UpdateOrderPending(int orderId)
        {
            var orderObj = _context.Order.Find(orderId);
            int drugQuantity;
            var getDetails = _context.OrderDetails.Where(a => a.OrderId == orderObj.ID).ToList();
            foreach (var item in getDetails)
            {

                if (orderObj.pharmacyTargetID > 0)
                {
                    var druglstDrugs = _context.DrugDetails.Where(a => a.drugID == item.drugID && orderObj.pharmacyTargetID == a.pharmacyLoggedInID).ToList();
                    
                    if (druglstDrugs.Count == 0)
                    {
                        drugQuantity = druglstDrugs[0].Quentity;
                        var drugDetailsObj = new DrugDetails();
                        drugDetailsObj.drugID = item.drugID;
                        drugDetailsObj.Quentity = item.QuentityInEachOrder;
                        _context.DrugDetails.Add(drugDetailsObj);
                        _context.SaveChanges();
                    }
                    else
                    {
                        drugQuantity = druglstDrugs[0].Quentity;
                        drugQuantity = drugQuantity + item.QuentityInEachOrder;
                        DrugDetails drugDetails = _context.DrugDetails.Where(a => a.drugID == item.drugID && orderObj.pharmacyTargetID == a.pharmacyLoggedInID).FirstOrDefault();
                        drugDetails.Quentity = drugQuantity;
                        _context.Entry(drugDetails).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

                if (orderObj.pharmacySourceID > 0)
                {
                    var druglstDrugs = _context.DrugDetails.Where(a => a.drugID == item.drugID && orderObj.pharmacySourceID == a.pharmacyLoggedInID).ToList();

                    if (druglstDrugs.Count == 0)
                    {
                        drugQuantity = druglstDrugs[0].Quentity;
                        var drugDetailsObj = new DrugDetails();
                        drugDetailsObj.drugID = item.drugID;
                        drugDetailsObj.Quentity = item.QuentityInEachOrder;
                        _context.DrugDetails.Add(drugDetailsObj);
                        _context.SaveChanges();
                    }
                    else
                    {
                        drugQuantity = druglstDrugs[0].Quentity;
                        drugQuantity = drugQuantity - item.QuentityInEachOrder;
                        DrugDetails drugDetails = _context.DrugDetails.Where(a => a.drugID == item.drugID && orderObj.pharmacySourceID == a.pharmacyLoggedInID).FirstOrDefault();
                        drugDetails.Quentity = drugQuantity;
                        _context.Entry(drugDetails).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }

            }

            var orderVMObj = orderObj.EditOrderPendingStatus();
            orderObj.PendingStatus = false;
            _context.Entry(orderObj).State = EntityState.Modified;
            _context.SaveChanges();

            return orderVMObj;
        }

        // GET: api/Orders
        [HttpGet]
        [Route("GetOrderByPharmacySourceId/{pharmacyId}")]
        public ActionResult<IEnumerable<OrderVM>> GetOrderByPharmacyId(int pharmacyId)
        {
            var lstOrders = _context.Order.ToList();
            var lstOrderDetails = _context.OrderDetails.ToList();
            var lstAllOrders = (from order in lstOrders
                                join detail in lstOrderDetails on order.ID equals detail.OrderId 
                                where order.pharmacySourceID == pharmacyId || order.pledgeId !=null
                                select new OrderVM
                                {
                                    OrderId = order.ID,
                                    PendingStatus= order.PendingStatus,
                                    Number = order.Number,
                                    Comments = order.Comments,
                                    pledgeId = order.pledgeId,
                                    pharmacyTargetId= order.pharmacyTargetID,
                                    supplierID = order.supplierID,
                                    SupplierName = order.supplierID == null ? "" : _context.Supplier.Where(a => a.ID == order.supplierID).FirstOrDefault().Name,
                                    IsDeleted= order.IsDeleted,
                                    PatientName = order.patientId == null ? "" : _context.Patients.Where(a => a.ID == order.patientId).FirstOrDefault().Name,
                                    PledgeName = order.pledgeId == null ? "" : _context.Pledge.Where(a => a.ID == order.pledgeId).FirstOrDefault().Name,

                                    pharmacyTarget = order.pharmacyTargetID == 0 ?  "": _context.Pharmacy.Where(a => a.ID == order.pharmacyTargetID).FirstOrDefault().Name,

                                    ListDetails = (List<OrderDetailVM>)order.orderDetailList.Where(a => a.OrderId == order.ID).Select(item => new OrderDetailVM
                                    {
                                        DrugName = _context.Drug.Where(a=>a.ID == item.drugID).FirstOrDefault().TradeName,
                                        Price = _context.OrderDetails.Where(a=>a.Price == item.Price).FirstOrDefault().Price,
                                        quentityInEachOrder = _context.OrderDetails.Where(a => a.QuentityInEachOrder == item.QuentityInEachOrder).FirstOrDefault().QuentityInEachOrder,
                                    }).ToList()

                                }).GroupBy(a=>a.OrderId).ToList();
            List<OrderVM> list = new List<OrderVM>();
            foreach (var item in lstAllOrders)
            {
                list.Add( item.FirstOrDefault());
            }
            return list;
        }

        [HttpGet]
        [Route("GetOrderByPharmacyTargetId/{pharmacyId}")]
        public ActionResult<IEnumerable<OrderVM>> GetOrderByPharmacyTargetId(int pharmacyId)
        {
            var lstOrders = _context.Order.ToList();
            var lstOrderDetails = _context.OrderDetails.ToList();
            var lstAllOrders = (from order in lstOrders
                                join detail in lstOrderDetails on order.ID equals detail.OrderId
                                where order.pharmacyTargetID == pharmacyId 
                                select new OrderVM
                                {
                                    OrderId = order.ID,
                                    PendingStatus = order.PendingStatus,
                                    IsDeleted = order.IsDeleted,
                                    Number = order.Number,
                                    Comments = order.Comments,
                                    pharmacyTargetId = order.pharmacyTargetID,
                                    pharmacySource = _context.Pharmacy.Where(a => a.ID == order.pharmacySourceID).FirstOrDefault().Name,
                                    ListDetails = (List<OrderDetailVM>)order.orderDetailList.Where(a => a.OrderId == order.ID).Select(item => new OrderDetailVM
                                    {
                                        //  SupplierName = ordr.Supplier.Name,
                                        DrugName = _context.Drug.Where(a => a.ID == item.drugID).FirstOrDefault().TradeName,
                                        Price = _context.OrderDetails.Where(a => a.Price == item.Price).FirstOrDefault().Price,
                                        quentityInEachOrder = _context.OrderDetails.Where(a => a.QuentityInEachOrder == item.QuentityInEachOrder).FirstOrDefault().QuentityInEachOrder,

                                    }).ToList()

                                }).GroupBy(a => a.OrderId).ToList();
            List<OrderVM> list = new List<OrderVM>();
            foreach (var item in lstAllOrders)
            {
                list.Add(item.FirstOrDefault());
            }
            return list;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.ID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  IActionResult PostOrder(Order order)
        {
            _context.Order.Add(order);

            if (order.supplierID == 0)
            {
                Supplier supplier = new Supplier();
                order.supplierID = supplier.ID;

            }

            if (order.pledgeId == 0)
            {
                Pledge pledge = new Pledge();
                order.pledgeId = null;
            }
            if (order.patientId == 0)
            {
                Patient pledge = new Patient();
                order.patientId = null;
            }
            else
            {
                var orderID = _context.SaveChanges();
            }
            var lst = order.orderDetailList.ToList();
            _context.SaveChanges();


            return Ok();
        }

        [HttpPut]
        [Route("DeleteOrder/{orderId}")]
        public async Task<IActionResult> OrderSoftDelete(int orderId)
        {
          var ord = _context.Order.Where(a => a.ID == orderId).ToList();
            ord[0].IsDeleted = true;
            _context.Entry(ord[0]).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.ID == id);
        }
    }
}
