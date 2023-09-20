import { Component } from '@angular/core';
import { COMMENTS, POSTS, USERS } from '../../mock-data';


@Component({
  selector: 'app-homescreen',
  templateUrl: './homescreen.component.html',
  styleUrls: ['./homescreen.component.css']
})
export class HomescreenComponent {
  posts = POSTS;
  users = USERS;
  comments = COMMENTS;

  app_name = "Post it!" 

  removePost(index: number){
    //console.log(index);
    this.posts.splice(index, 1);
  }
}
