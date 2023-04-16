using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using EducationPlatform_GraduationProject.Models;
using EducationPlatform_GraduationProject.Data;


namespace EducationPlatform_GraduationProject.Hubs
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext context;

        public ChatHub(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task SendMessage(string usergroupname , string message1)
        {
           if(!String.IsNullOrWhiteSpace(message1))
            {
                string logedUserName = Context.User.Identity.Name;
                int userGroupId = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Select(g => g.Class.Chat.ChatId).FirstOrDefaultAsync();
                var logeduser = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Where(m => m.ClassID == userGroupId).Select(m => m).FirstOrDefaultAsync();
                var roleName = await context.UserRoles.Where(r => r.UserId == logeduser.IdentityUserId).Select(r => r.RoleId).FirstOrDefaultAsync();
               
                if (roleName != "Admin")
                {
                    string userGroupName = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Select(g => g.Class.Chat.Title).FirstOrDefaultAsync();
                    await Groups.AddToGroupAsync(Context.ConnectionId, userGroupName);
                    if (logeduser != null)
                    {
                        Messages message = new Messages();
                        message.StID = logeduser.StId;
                        message.Body = message1;
                        message.ChatID = userGroupId;
                        message.Date = DateTime.Now; //.ToString("MM/dd/yyyy hh:mm tt");//  
                        await context.Messages.AddAsync(message);
                        await context.SaveChangesAsync();
                        await Clients.Group(userGroupName).SendAsync("ReceiveMessage", logeduser.StName, message1, message.Date.ToString("hh:mm tt"));
                    }
                }
                else
                {
                    var userGroupIdd = await context.Classes.Where(c => c.Title == usergroupname).Select(m => m.ClassId).FirstOrDefaultAsync();
                    await Groups.AddToGroupAsync(Context.ConnectionId, usergroupname);
                    Messages message = new Messages();
                    message.StID = logeduser.StId;
                    message.Body = message1;
                    message.ChatID = userGroupIdd;
                    message.Date = DateTime.Now; //.ToString("MM/dd/yyyy hh:mm tt");//  
                    await context.Messages.AddAsync(message);
                    await context.SaveChangesAsync();
                    await Clients.Group(usergroupname).SendAsync("ReceiveMessage", logeduser.StName, message1, message.Date.ToString("hh:mm tt"));
                }
            }
        }

        public async override Task OnConnectedAsync()
        {
            string logedUserName = Context.User.Identity.Name;
            int userGroupId = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Select(g => g.Class.Chat.ChatId).FirstOrDefaultAsync();
            var logeduser = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Where(m => m.ClassID == userGroupId).Select(m => m).FirstOrDefaultAsync();
            var roleName = await context.UserRoles.Where(r => r.UserId == logeduser.IdentityUserId).Select(r => r.RoleId).FirstOrDefaultAsync();
            if (roleName != "Admin")
            {
                string userGroupName = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Select(g => g.Class.Chat.Title).FirstOrDefaultAsync();
                await Groups.AddToGroupAsync(Context.ConnectionId, userGroupName);
                // Retrieve messages from database
                var messages = await context.Messages.Where(n => n.ChatID == userGroupId).OrderBy(m => m.Date).ToListAsync();
                // Send messages to the client
                foreach (var message in messages)
                {
                    string studName = await context.Students.Where(u => u.StId == message.StID).Select(g => g.StName).FirstOrDefaultAsync();
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", studName, message.Body, message.Date.ToString("hh:mm tt"));//message.StIdfkNavigation.StName
                }
            }
        }
  
        public async Task ShowChat(string usergroupname)
        {
            string logedUserName = Context.User.Identity.Name;
            int userGroupId = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Select(g => g.Class.Chat.ChatId).FirstOrDefaultAsync();
            var logeduser = await context.Students.Where(m => m.IdentityUser.Email == logedUserName).Where(m => m.ClassID == userGroupId).Select(m => m).FirstOrDefaultAsync();
            var roleName = await context.UserRoles.Where(r => r.UserId == logeduser.IdentityUserId).Select(r => r.RoleId).FirstOrDefaultAsync();
            if (roleName == "Admin")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, usergroupname);
                // Retrieve messages from database
                var messages = await context.Messages.Where(n => n.Chat.Title == usergroupname).OrderBy(m => m.Date).ToListAsync();
                // Send messages to the client
                foreach (var message in messages)
                {
                    string studName = await context.Students.Where(u => u.StId == message.StID).Select(g => g.StName).FirstOrDefaultAsync();
                    await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", studName, message.Body, message.Date.ToString("hh:mm tt"));//message.StIdfkNavigation.StName
                }
            }
        }
    }
}