import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TopicService } from 'src/app/services/topic.service';
import { Topic } from 'src/models/topic';
import { Comment } from 'src/models/comment';
import { CommentService } from 'src/app/services/comment.service';

@Component({
  selector: 'app-topic-detail',
  templateUrl: './topic-detail.component.html',
  styleUrls: ['./topic-detail.component.css']
})
export class TopicDetailComponent implements OnInit {

  id : number;
  currentTopic : Topic
  commentForm: FormGroup;

  constructor(private route : ActivatedRoute, private topicService : TopicService, private commentService : CommentService) { 
    this.id = route.snapshot.params["id"];

    this.commentForm = new FormGroup({
      userControl: new FormControl(null, Validators.required),
      contentControl: new FormControl(null, Validators.required)
    });
  }

  ngOnInit(): void {
    this.loadComments();
  }

  loadComments(): void {
    this.topicService.getTopicById(this.id).subscribe((data : any) => {
      this.currentTopic = data;
    })
  }

  addComment(idTopic: number): void {
      let comment = new Comment(undefined, undefined, undefined, this.commentForm.get("userControl").value, this.commentForm.get("contentControl").value, idTopic);

      this.commentService.createComment(comment).subscribe((data: string) => {
        this.loadComments()
      });

      this.commentForm.reset();
  }

  deleteComment(idComment: number){
    this.commentService.deleteComment(idComment).subscribe((data: string) => {
      this.loadComments()
    });
  }
}
