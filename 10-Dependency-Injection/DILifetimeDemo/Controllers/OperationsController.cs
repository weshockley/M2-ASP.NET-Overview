using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DILifetimeDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DILifetimeDemo.Controllers
{
    public class OperationsController : Controller
    {
		private readonly OperationService _operationService;
		private readonly IOperationTransient _transientOperation;
		private readonly IOperationScoped _scopedOperation;
		private readonly IOperationSingleton _singletonOperation;
		private readonly IOperationInstance _instanceOperation;

		private static int _count = 0;

		public OperationsController(OperationService operationService,
			IOperationTransient transientOperation,
			IOperationScoped scopedOperation,
			IOperationSingleton singletonOperation,
			IOperationInstance instanceOperation)
		{
			_operationService = operationService;
			_transientOperation = transientOperation;
			_scopedOperation = scopedOperation;
			_singletonOperation = singletonOperation;
			_instanceOperation = instanceOperation;
		}

		public IActionResult Index()
		{
			ViewBag.Transient = _transientOperation;
			ViewBag.Scoped = _scopedOperation;
			ViewBag.Singleton = _singletonOperation;
			ViewBag.Instance = _instanceOperation;
			ViewBag.Service = _operationService;
			ViewBag.Count = ++_count;
			return View();
		}
	}
}