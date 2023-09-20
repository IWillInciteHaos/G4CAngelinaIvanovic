export class Comment {
    
    ID: number;
    isActive : boolean;
    Message : string;
    CreatorID : number;
    LikeCount : number;
    OriginPostID : number;
    
    constructor(message: string = "", cID : number, likes = 0, pID : number){
        this.ID = -1;
        this.isActive = true;
        this.Message = message;
        this.CreatorID = cID;
        this.LikeCount = likes;
        this.OriginPostID = pID;
    }

}