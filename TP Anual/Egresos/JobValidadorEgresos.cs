
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace TP_Anual.Egresos
{
    class JobValidadorEgresos : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Egreso egreso = (Egreso)context.JobDetail.JobDataMap.Get("egreso");
            ValidadorDeEgreso.egresoValido(egreso);
            await Console.Out.WriteLineAsync("validacion de egreso realizada");

        }

    }
}
