﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using ChatApplication.Models;
using ChatApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChatApplication.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionService<string> _connections =
          new ConnectionService<string>();

        public async Task Send(string data,string connId)
        {
            await Clients.Client(Context.ConnectionId).SendAsync("send", data);
            await Clients.Client(connId).SendAsync("send", data);
        }

        public async Task upData()
        {
          await Clients.Client(Context.ConnectionId).SendAsync("upData", Context.ConnectionId);
        }

    }
}
