﻿using Newtonsoft.Json;
using ZKWebStandard.Extensions;
using ZKWebStandard.Web;

namespace ZKWeb.Web.ActionResults {
	/// <summary>
	/// Json result
	/// </summary>
	public class JsonResult : IActionResult {
		/// <summary>
		/// The object serialize to json
		/// </summary>
		public object Object { get; set; }
		/// <summary>
		/// Serialize formatting
		/// </summary>
		public Formatting SerializeFormatting { get; set; }

		/// <summary>
		/// Initialize
		/// </summary>
		/// <param name="obj">The object serialize to json</param>
		/// <param name="formatting">Serialize formatting</param>
		public JsonResult(object obj, Formatting formatting = Formatting.None) {
			Object = obj;
			SerializeFormatting = formatting;
		}

		/// <summary>
		/// Write json to http response
		/// </summary>
		/// <param name="response">Http response</param>
		public void WriteResponse(IHttpResponse response) {
			// Set status and mime
			response.StatusCode = 200;
			response.ContentType = "application/json";
			// Write json to http response
			response.Write(JsonConvert.SerializeObject(Object, SerializeFormatting));
		}
	}
}
