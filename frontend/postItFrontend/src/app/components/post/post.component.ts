import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Post } from './post.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {
  @Input()
  post: Post = new Post(-1, false, "", "", -1);
  @Input()
  index: number = -1;
  isLiked: boolean = false

  @Output() emitDelete : EventEmitter<number> = new EventEmitter<number>()

  addLike(){

    !this.isLiked ? this.post.LikeCount++ : this.post.LikeCount--;
    this.isLiked = !this.isLiked;
  }

  deletePost(){
    this.emitDelete.emit(this.index);
  }
}
