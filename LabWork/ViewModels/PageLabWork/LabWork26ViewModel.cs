using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork26ViewModel : ViewModelBase
    {
        private HttpClient httpClient = new();

        internal static LabWork26ViewModel LabWork26ViewModelInstanse { get; set; } = new();

        private string userId = string.Empty;
        public string UserId
        {
            get => userId;
            set => this.RaiseAndSetIfChanged(ref userId, value);
        }

        private string userSite = string.Empty;

        public string UserSite
        {
            get => userSite;
            set => this.RaiseAndSetIfChanged(ref userSite, value);
        }

        private string postsUsers = string.Empty;

        public string PostsUsers
        {
            get => postsUsers;
            set => this.RaiseAndSetIfChanged(ref postsUsers, value);
        }

        private string usersCount = string.Empty;

        public string UsersCount
        {
            get => usersCount;
            set => this.RaiseAndSetIfChanged(ref usersCount, value);
        }

        private string midleUserPost = string.Empty;

        public string MidleUserPost
        {
            get => midleUserPost;
            set => this.RaiseAndSetIfChanged(ref midleUserPost, value);
        }
        
        internal LabWork26ViewModel()
        {
            LabWork26ViewModelInstanse = this;
        }

        internal async Task<string> GetPosts(bool statusGet = true)
        {

            var response = await httpClient.GetAsync(
                statusGet
                    ? "https://jsonplaceholder.typicode.com/posts"
                    : $"https://jsonplaceholder.typicode.com/users/{UserId}/posts");
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();

            var listPost = JsonSerializer.Deserialize<List<Post>>(responseJson);
            Data.ObjectDataReport.AddRange(listPost!);
            UsersCount = "Юзеров всего:" + listPost!.GroupBy(x => x.userId).ToList().Count;
            PostsUsers = "Постов всего:" + listPost!.Count;
            if (!statusGet)
                MidleUserPost = "Среднее кол-во постов у юзера:" + (listPost.Count / 2);

            return responseJson;
        }

        internal async Task DownloadFile()
        {
            await using var stream = await httpClient.GetStreamAsync(UserSite);
            await using var fileStream = new FileStream($"{Environment.CurrentDirectory}\\Download", FileMode.Create);
            await stream.CopyToAsync(fileStream);
        }

        /// <summary>
        /// Функция запрашивает спряжения для задействованого глагола отвечающего на вопрос "Что сделать?".
        /// </summary>
        /// <param name="can">Глагол для которого требуется запросить спряжения.</param>
        /// <exception cref="WebException">Ошибка возникает, если спряжения данного глагола не найдены или браузер на компьютере пользователя не функционирует должным образом.</exception>
        internal async Task CanSearch()
        {
            var can = "Убить";
            var dataSearch = "<trclass=\"table-primary\"><th>Мужской род</th><th>Женский род</th><th>Средний род</th></tr>";

            List<string> dataList = new();

            try
            {
                var response = await httpClient.GetAsync($@"https://inflectonline.ru/{can.Replace(":", "").ToLower().Replace("ё", "е")}");
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                using (StreamReader str = new(stream))
                {
                    var data = await str.ReadToEndAsync();
                    data = data.Replace(" ", "");
                    data = data.Substring(data.IndexOf(dataSearch.Replace(" ", ""), StringComparison.Ordinal));
                    data = data.Remove(0, data.IndexOf("</td>\n</tr>\n<tr>\n<td>", StringComparison.Ordinal));
                    data = data.Remove(data.IndexOf("</td>\n</tr>\n</tbody>\n", StringComparison.Ordinal));
                    dataList = data.Split('\n').ToList();
                    dataList = dataList.Where(x => x.Contains("<td>")).ToList();
                }

                dataList = dataList.Select(responce =>
                {
                    responce = responce.Replace("</td>", "");
                    responce = responce.Replace("<td>", "");
                    return responce;
                }).ToList();
            }
            catch (WebException)
            {
            }
            Data.ObjectDataReport.AddRange(dataList);
        }
    }
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
