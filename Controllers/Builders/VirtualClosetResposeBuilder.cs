using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artisan.Service.Core.Web;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Controllers.Contracts;
using VirtualClosetAPI.Controllers.Extensions;

namespace VirtualClosetAPI.Controllers.Builders
{
    /// <summary>
    /// Converts <see cref="Account"/> models to <see cref="AccountResponse"/>.
    /// </summary>
    internal class VirtualClosetResponseBuilder : IMessageBuilder<VirtualCloset, VirtualClosetResponse>
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<VirtualClosetResponse>> Build(IMessageBuilderContext<VirtualCloset, VirtualClosetResponse> context)
        {
            var results = new List<VirtualClosetResponse>();

            foreach (var obj in context.Items)
            {
                var response = obj.ToResponse();

                results.Add(response);
            }

            return results;
        }
    }
}

