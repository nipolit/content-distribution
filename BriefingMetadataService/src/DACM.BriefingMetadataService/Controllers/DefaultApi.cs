/*
 * BriefingMetadataService
 *
 * Service providing briefing metadata
 *
 * OpenAPI spec version: 0.0.1
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Collections.Generic;
using DACM.BriefingMetadataService.Attributes;
using DACM.BriefingMetadataService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DACM.BriefingMetadataService.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private Services.BriefingMetadataService _briefingMetadataService;
        public DefaultApiController()
        {
            _briefingMetadataService = new Services.BriefingMetadataService();
        }
        
        /// <summary>
        /// Responds with briefing metadata for requested asset IDs
        /// </summary>
        /// <remarks>Responds with briefing metadata for requested asset IDs</remarks>
        /// <param name="assetIds">Asset IDs</param>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Invalid input</response>
        /// <response code="422">Validation exception</response>
        [HttpPost]
        [Route("/asset-ids")]
        [ValidateModelState]
        [SwaggerOperation("FetchBriefingMetadata")]
        [SwaggerResponse(statusCode: 200, type: typeof(IList<BriefingMetadata>), description: "Successful operation")]
        public virtual IActionResult FetchBriefingMetadata(IList<string> assetIds)
        {
            System.Threading.Thread.Sleep(200); // Slow down the API request
            var assetMetadataList = _briefingMetadataService.FetchBriefingMetadata(assetIds);
            return new OkObjectResult(assetMetadataList);
        }
    }
}
