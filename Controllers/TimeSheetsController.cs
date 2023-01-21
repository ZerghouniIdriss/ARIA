using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Data;
using SPA.Models;
using SPA.Utils;

namespace SPA.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TimeSheetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetsController(ApplicationDbContext context)
        {
            _context = context;

        }

        // GET: api/TimeSheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSheet>>> GetTimeSheets()
        {
            return await _context.TimeSheets.ToListAsync();
        }

        // GET: api/TimeSheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSheet>> GetTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheets.FindAsync(id);

            if (timeSheet == null)
            {
                return NotFound();
            }

            return timeSheet;
        }

        // PUT: api/TimeSheets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeSheet(int id, TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(id))
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

        // POST: api/TimeSheets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeSheet>> PostTimeSheet(TimeSheetViewModel viewModel)
        {
            TimeSheet timeSheet = MapTimeSheetViewModelToTimeSheet(viewModel);

            var existingTimeSheet = await _context.TimeSheets.AsNoTracking().FirstOrDefaultAsync(ts => ts.Id == timeSheet.Id);

            if (existingTimeSheet == null)
            {
                timeSheet.Id = 0;
                _context.TimeSheets.Add(timeSheet);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.TimeSheets.Update(timeSheet);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetTimeSheet", new { id = timeSheet.Id }, MapTimeSheetToTimeSheetViewModel(timeSheet));
        }


        // DELETE: api/TimeSheets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSheet(int id)
        {
            var timeSheet = await _context.TimeSheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            _context.TimeSheets.Remove(timeSheet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{employeeId}/{weekDate}")]
        public async Task<ActionResult<TimeSheetViewModel>> GetTimeSheetByEmployeeIdAndWeekDate(string employeeId, string weekDate)
        {
            DateTime parsedWeekDate = DateTime.Parse(weekDate);
            var sunday= DateUtils.GetAssociatedSunday(parsedWeekDate).Date;
            // retrieve the timesheet using the employeeId and weekDate
             TimeSheet timesheet = _context.TimeSheets.FirstOrDefault(t => t.EmployeeId == employeeId && t.WeekDate.Date == sunday);
            if (timesheet == null)
            {
                return Ok(null);
            }
            return this.MapTimeSheetToTimeSheetViewModel(timesheet);
        }

        private bool TimeSheetExists(int id)
        {
            return _context.TimeSheets.Any(e => e.Id == id);
        }



        public TimeSheet MapTimeSheetViewModelToTimeSheet(TimeSheetViewModel viewModel)
        {
            TimeSheet timeSheet = new TimeSheet
            {
                Id = viewModel.Id,
                EmployeeId = viewModel.EmployeeId,
                WeekDate =  DateUtils.GetAssociatedSunday(viewModel.WeekDate.Date).Date,
                D0Regular = viewModel.D0.Regular,
                D0Overtime = viewModel.D0.Overtime,
                D0Vacation = viewModel.D0.Vacation,
                D0Holiday = viewModel.D0.Holiday,
                D1Regular = viewModel.D1.Regular,
                D1Overtime = viewModel.D1.Overtime,
                D1Vacation = viewModel.D1.Vacation,
                D1Holiday = viewModel.D1.Holiday,
                D2Regular = viewModel.D2.Regular,
                D2Overtime = viewModel.D2.Overtime,
                D2Vacation = viewModel.D2.Vacation,
                D2Holiday = viewModel.D2.Holiday,
                D3Regular = viewModel.D3.Regular,
                D3Overtime = viewModel.D3.Overtime,
                D3Vacation = viewModel.D3.Vacation,
                D3Holiday = viewModel.D3.Holiday,
                D4Regular = viewModel.D4.Regular,
                D4Overtime = viewModel.D4.Overtime,
                D4Vacation = viewModel.D4.Vacation,
                D4Holiday = viewModel.D4.Holiday,
                D5Regular = viewModel.D5.Regular,
                D5Overtime = viewModel.D5.Overtime,
                D5Vacation = viewModel.D5.Vacation,
                D5Holiday = viewModel.D5.Holiday,
                D6Regular = viewModel.D6.Regular,
                D6Overtime = viewModel.D6.Overtime,
                D6Vacation = viewModel.D6.Vacation,
                D6Holiday = viewModel.D6.Holiday,
                Tasks = viewModel.Tasks,
                Comments = viewModel.Comments,
                Status = viewModel.Status
            };

            return timeSheet;
        }

        public TimeSheetViewModel MapTimeSheetToTimeSheetViewModel(TimeSheet timeSheet)
        {
            return new TimeSheetViewModel
            {
                Id = timeSheet.Id,
                EmployeeId = timeSheet.EmployeeId,
                WeekDate = timeSheet.WeekDate,
                Comments = timeSheet.Comments,
                Tasks = timeSheet.Tasks,
                Status = timeSheet.Status,
                D0 = new Day
                {
                    Regular = timeSheet.D0Regular,
                    Overtime = timeSheet.D0Overtime,
                    Vacation = timeSheet.D0Vacation,
                    Holiday = timeSheet.D0Holiday
                },
                D1 = new Day
                {
                    Regular = timeSheet.D1Regular,
                    Overtime = timeSheet.D1Overtime,
                    Vacation = timeSheet.D1Vacation,
                    Holiday = timeSheet.D1Holiday
                },
                D2 = new Day
                {
                    Regular = timeSheet.D2Regular,
                    Overtime = timeSheet.D2Overtime,
                    Vacation = timeSheet.D2Vacation,
                    Holiday = timeSheet.D2Holiday
                },
                D3 = new Day
                {
                    Regular = timeSheet.D3Regular,
                    Overtime = timeSheet.D3Overtime,
                    Vacation = timeSheet.D3Vacation,
                    Holiday = timeSheet.D3Holiday
                },
                D4 = new Day
                {
                    Regular = timeSheet.D4Regular,
                    Overtime = timeSheet.D4Overtime,
                    Vacation = timeSheet.D4Vacation,
                    Holiday = timeSheet.D4Holiday
                },
                D5 = new Day
                {
                    Regular = timeSheet.D5Regular,
                    Overtime = timeSheet.D5Overtime,
                    Vacation = timeSheet.D5Vacation,
                    Holiday = timeSheet.D5Holiday
                },
                D6 = new Day
                {
                    Regular = timeSheet.D6Regular,
                    Overtime = timeSheet.D6Overtime,
                    Vacation = timeSheet.D6Vacation,
                    Holiday = timeSheet.D6Holiday
                }
            };
        }



    }
}
