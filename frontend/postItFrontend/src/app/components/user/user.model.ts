import { Post } from "../post/post.model";
export class User{
    username: string;
    password: string;
    ID?: number;
    isActive: boolean;
    email: string;
    followers?: User[];
    following?: User[]
    Posts?: Post[];

    constructor(user: string, pass: string, mail: string){
        this.username = user;
        this.password = pass;
        this.email = mail;   
        this.isActive = true;
        this.followers = [];
        this.following = [];
        this.Posts = [];
    }
}