import { Post } from './components/post/post.model'
import { User } from './components/user/user.model'
import { Comment } from '../app/components/comment/comment.model';

export const COMMENTS: Comment[] = [
    {ID: 1, isActive: true, Message: "this is a comment!", CreatorID: 1, OriginPostID: 0, LikeCount: 3 },
    {ID: 2, isActive: true, Message: "this comment?", CreatorID: 1, OriginPostID: 4, LikeCount: 0 },
    {ID: 3, isActive: true, Message: "soemthing here!", CreatorID: 2, OriginPostID: 5, LikeCount: 8 }
];

export const POSTS: Post[] = [
    { ID: 0, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say", CreatorUsername : "user1", CreatorID: 1, LikeCount: 0 },
    { ID: 1, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say 2", CreatorUsername : "user2", CreatorID: 2, LikeCount: 7 },
    { ID: 2, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say 3", CreatorUsername : "user1", CreatorID: 1, LikeCount: 2 },
    { ID: 3, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say 4", CreatorUsername : "user3", CreatorID: 3, LikeCount: 6 },
    { ID: 4, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say 5", CreatorUsername : "user1", CreatorID: 1, LikeCount: 1 },
    { ID: 5, isActive : true, DateCreated: Date.toString(), Content: "Some stuff to say 6", CreatorUsername : "user2", CreatorID: 2, LikeCount: 3 }
];

export const USERS: User[] = [
    {username: 'user1', password: 'pass', isActive: true, email: 'mail@mail', followers: [], following: [], Posts: [] },
    {username: 'user2', password: 'pass2', isActive: true, email: 'mail2@mail', followers: [], following: [], Posts: [] },
    {username: 'user3', password: 'pass3', isActive: true, email: 'mail3@mail', followers: [], following: [], Posts: [] }

];