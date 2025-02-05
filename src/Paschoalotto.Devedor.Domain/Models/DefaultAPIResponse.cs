﻿using Paschoalotto.Devedor.Domain.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paschoalotto.Devedor.Domain.Models
{
    public class DefaultAPIResponse
    {
        public bool Success { get; set; }

        public dynamic Data { get; set; }

        public List<NotificationMessage> Notifications { get; set; }
    }
}
