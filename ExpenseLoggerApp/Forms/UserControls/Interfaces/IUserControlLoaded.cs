using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLoggerApp.Forms.UserControls.Interfaces
{
    public interface IUserControlLoaded
    {
        // Force all the user controls to implement this method.
        // The method is used to show form's default data.
        void LoadFormData();
    }
}
