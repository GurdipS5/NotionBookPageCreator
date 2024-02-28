// See https://aka.ms/new-console-template for more information
using Notion.Client;

Console.WriteLine("Hello, World!");

var client = NotionClientFactory.Create(new ClientOptions
{
    AuthToken = "<Token>"
});

// client.Pages.CreateAsync()

    new PagesCreateParameters();