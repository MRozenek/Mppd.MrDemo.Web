using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mppd.MrDemo.Web.Models;

namespace Mppd.MrDemo.Web.Controllers
{
  public class HierarchyTreeController : Controller
    {
        private readonly MddpMrDemoContext _context;

        public HierarchyTreeController(MddpMrDemoContext context)
        {
            _context = context;
        }

        // GET: HierarchyTree
        public async Task<IActionResult> Index()
        {
            var mddpMrDemoContext = _context.HierarchyTrees
                .Include(h => h.Resource)
                .Include(h => h.ResourceManager)
                .Include(h => h.ResourceParent);
            return View(await mddpMrDemoContext.ToListAsync());
        }

        // GET: HierarchyTree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HierarchyTrees == null)
            {
                return NotFound();
            }

            var hierarchyTree = await _context.HierarchyTrees
                .Include(h => h.Resource)
                .Include(h => h.ResourceManager)
                .Include(h => h.ResourceParent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hierarchyTree == null)
            {
                return NotFound();
            }

            return View(hierarchyTree);
        }

        // GET: HierarchyTree/Create
        public IActionResult Create()
        {
            ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Id");
            ViewData["ResourceManagerId"] = new SelectList(_context.Resources, "Id", "Id");
            ViewData["ResourceParentId"] = new SelectList(_context.Resources, "Id", "Id");
            return View();
        }

        // POST: HierarchyTree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,ResourceParentId,ResourceManagerId")] HierarchyTree hierarchyTree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hierarchyTree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceId);
            ViewData["ResourceManagerId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceManagerId);
            ViewData["ResourceParentId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceParentId);
            return View(hierarchyTree);
        }

        // GET: HierarchyTree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HierarchyTrees == null)
            {
                return NotFound();
            }

            var hierarchyTree = await _context.HierarchyTrees
                .Include(h => h.Resource)
                .Include(h => h.ResourceManager)
                .Include(h => h.ResourceParent)
                .SingleAsync(x => x.Id == id);
            if (hierarchyTree == null)
            {
                return NotFound();
            }

            ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceId);
            ViewData["ResourceManagerId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceManagerId);
            ViewData["ResourceParentId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceParentId);
            return View(hierarchyTree);
        }

        // POST: HierarchyTree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,ResourceParentId,ResourceManagerId")] HierarchyTree hierarchyTree)
        {
            if (id != hierarchyTree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hierarchyTree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HierarchyTreeExists(hierarchyTree.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceId);
            ViewData["ResourceManagerId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceManagerId);
            ViewData["ResourceParentId"] = new SelectList(_context.Resources, "Id", "Id", hierarchyTree.ResourceParentId);
            return View(hierarchyTree);
        }

        // GET: HierarchyTree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HierarchyTrees == null)
            {
                return NotFound();
            }

            var hierarchyTree = await _context.HierarchyTrees
                .Include(h => h.Resource)
                .Include(h => h.ResourceManager)
                .Include(h => h.ResourceParent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hierarchyTree == null)
            {
                return NotFound();
            }

            return View(hierarchyTree);
        }

        // POST: HierarchyTree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HierarchyTrees == null)
            {
                return Problem("Entity set 'MddpMrDemoContext.HierarchyTrees'  is null.");
            }
            var hierarchyTree = await _context.HierarchyTrees.FindAsync(id);
            if (hierarchyTree != null)
            {
                _context.HierarchyTrees.Remove(hierarchyTree);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HierarchyTreeExists(int id)
        {
          return (_context.HierarchyTrees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
