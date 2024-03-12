// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Notion.Client;

Console.WriteLine("Hello, World!");

string notionApiKey = @"secret_xcu8cG7DWOBbgr522xghe1ciebuMGmZtcZaeiYtTma8";
string notionBaseUrl = "https://api.notion.com/v1/pages";
string pageId = "06c102bb542d417898c9cc529ad832af";

HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Notion-Version", "2022-06-28");

Uri u = new Uri(notionBaseUrl);

httpClient.BaseAddress = new Uri(notionBaseUrl);
httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {notionApiKey}");


var requestBody = new
{
    cover = new
    {
        type = "external",
        external = new
        {
            url = "https://upload.wikimedia.org/wikipedia/commons/6/62/Tuscankale.jpg"
        }
    },
    icon = new
    {
        type = "emoji",
        emoji = "🥬"
    },
    parent = new
    {
        type = "page_id",
        page_id = pageId
    },
    properties = new
    {
        Name = new
        {
            title = new[]
                    {
                        new
                        {
                            text = new
                            {
                                content = "Tuscan kale"
                            }
                        }
                    }
        },
        Description = new
        {
            rich_text = new[]
                    {
                        new
                        {
                            text = new
                            {
                                content = "A dark green leafy vegetable"
                            }
                        }
                    }
        },
        Food_group = new
        {
            select = new
            {
                name = "🥬 Vegetable"
            }
        }
    },
    children = new object[]
            {
                new
                {
                    @object = "block",
                    heading_2 = new
                    {
                        rich_text = new[]
                        {
                            new
                            {
                                text = new
                                {
                                    content = "Lacinato kale"
                                }
                            }
                        }
                    }
                },
                new
                {
                    @object = "block",
                    paragraph = new
                    {
                        rich_text = new[]
                        {
                            new
                            {
                                text = new
                                {
                                    content = "Lacinato kale is a variety of kale with a long tradition in Italian cuisine, especially that of Tuscany. It is also known as Tuscan kale, Italian kale, dinosaur kale, kale, flat back kale, palm tree kale, or black Tuscan palm.",
                                    link = new
                                    {
                                        url = "https://en.wikipedia.org/wiki/Lacinato_kale"
                                    }
                                },
                                href = "https://en.wikipedia.org/wiki/Lacinato_kale"
                            }
                        },
                        color = "default"
                    }
                }
            }


};



using HttpResponseMessage response = await httpClient.PostAsJsonAsync(u, requestBody);



var jsonResponse = await response.Content.ReadAsStringAsync();
Console.WriteLine($"{jsonResponse}\n");

Console.ReadLine();