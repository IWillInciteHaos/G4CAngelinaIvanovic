export class Post {
    
    ID : number;
    isActive: boolean;
    DateCreated: string;
    Content: string;
    LikeCount: number;
    CreatorUsername: string;
    CreatorID: number;
    Comments?: Comment[] ;

    constructor(id: number, active : boolean, post: string, cUsername : string, cID: number) {  
        this.ID = id;
        this.isActive = active;
        this.DateCreated = new Date().toString();
        this.Content = post;
        this.LikeCount = 0;
        this.CreatorUsername = cUsername;
        this.CreatorID = cID;
        this.Comments = [];
    }

    
}