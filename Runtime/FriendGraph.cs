using System.Collections.Generic;

namespace DailyCodingProblem1091
{
    public class FriendGraph
    {
        private readonly List<List<int>> firendsAdjacentList;

        public FriendGraph(List<List<int>> firendsAdjacentList)
        {
            this.firendsAdjacentList = firendsAdjacentList;
        }

        public List<List<int>> GetFriendGrups()
        {
            var friendGroups = new List<List<int>>();
            var bannedFriends = new List<int>();
            
            for (var currentFriend = 0; currentFriend < this.firendsAdjacentList.Count; currentFriend++)
            {
                if (bannedFriends.Contains(currentFriend))
                {
                    continue;
                }

                var currentFriends = this.firendsAdjacentList[currentFriend];

                List<int> groupFound = this.FindFriendGroup(friendGroups, currentFriends);

                if (groupFound == null)
                {
                    var newFriendsGroup = this.CreateNewFriendsGroup(currentFriends, currentFriend);
                    friendGroups.Add(newFriendsGroup);
                    bannedFriends.AddRange(newFriendsGroup);
                }
                else
                {
                    groupFound.Add(currentFriend);
                    bannedFriends.Add(currentFriend);
                }
            }

            return friendGroups;
        }

        private List<int> CreateNewFriendsGroup(List<int> currentFriends, int currentFriend)
        {
            var newFriendsGroup = new List<int>(currentFriends) { currentFriend };
            newFriendsGroup.Sort();

            return newFriendsGroup;
        }

        private List<int> FindFriendGroup(List<List<int>> friendGroups, List<int> currentFriends)
        {
            List<int> groupFound = null;

            foreach (int currentFriend in currentFriends)
            {
                groupFound = friendGroups.Find(friendGroup => friendGroup.Contains(currentFriend));
            }
            
            return groupFound;
        }
    }
}
