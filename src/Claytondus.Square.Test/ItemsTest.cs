using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Claytondus.Square.Test
{
    public class ItemsTest
    {
        [Fact]
        public async Task ApplyFeeTest()
        {
            var itemClient = new SquareItemClient("sq0atp-LlrTEYE7Y294tD4aOLmPpw", "465QAXW6Z408S");
            await
                itemClient.ApplyFeeAsync("09064fa2-134c-4c5b-a6fe-0467cc34e3ab", "0c698703-96d7-4049-9c89-e5a4d2f1cec3");

        }

        [Fact]
        public async Task RemoveFeeTest()
        {
            var itemClient = new SquareItemClient("sq0atp-LlrTEYE7Y294tD4aOLmPpw", "465QAXW6Z408S");
            await
                itemClient.RemoveFeeAsync("09064fa2-134c-4c5b-a6fe-0467cc34e3ab", "0c698703-96d7-4049-9c89-e5a4d2f1cec3");

        }

        [Fact]
        public async Task InsertImageTest()
        {
            var itemClient = new SquareItemClient("8t7pNBnW9HgPo7_P26wSIA");
            var webClient = new WebClient();
            var imageBytes =
                    webClient.DownloadData("http://newpos.galaxyfireworks.com/Blob.ashx?ItemsMobileImageHandler=o|3059");
            var imageResult =
                await itemClient.UploadItemImageAsync("test1234", imageBytes, "image/jpeg");
        }

        [Fact]
        public async Task DeleteItemTest()
        {
            var itemClient = new SquareItemClient("8t7pNBnW9HgPo7_P26wSIA");
            await itemClient.DeleteItemAsync("test1234");
        }
    }
}
