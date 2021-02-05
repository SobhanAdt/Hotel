using System;

namespace App.Core.ApplicationService.IRepositories.Exceptions
{
    public class AppExecption : ApplicationException
    {
        public AppExecption(string massage) : base(massage)
        {

        }
    }
}