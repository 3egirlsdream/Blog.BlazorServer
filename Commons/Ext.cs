using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlogBlazorServer.Commons
{
    public static class Ext
    {
        public static void Back(this NavigationManager navigation)
        {
            var jsruntime = Program.Services.BuildServiceProvider().GetService<IJSRuntime>();
            jsruntime.InvokeVoidAsync("history.back");
        }
    }
}
