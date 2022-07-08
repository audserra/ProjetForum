import { Component, Input, OnInit, Output } from '@angular/core';
import { Topic } from 'src/models/topic';
import { Comment } from 'src/models/comment';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-modal-modify',
  templateUrl: './modal-modify.component.html',
  styleUrls: ['./modal-modify.component.css']
})
export class ModalModifyComponent implements OnInit {

  @Input() comment: Comment;

  @Input() topic: Topic;

  @Output() updateComment = new EventEmitter<Comment>();

  @Output() updateTopic = new EventEmitter<Topic>();
  
  modifyForm: FormGroup;

  constructor(private modalService: NgbModal) { 
    this.modifyForm = new FormGroup({
      contentControl: new FormControl(null, Validators.required)
    });
  }

  ngOnInit(): void {
    if(this.comment != null){
        this.modifyForm.setValue({contentControl: this.comment.content});
    }
  }

  open(content) {
    this.modalService.open(content, { size: 'lg' });
  }

  validateUpdate(){
    if(this.comment != null){
      this.comment.content = this.modifyForm.get("contentControl").value;
      this.updateComment.emit(this.comment)
    }
    else{
      this.topic.title = this.modifyForm.get("contentControl").value;
      this.updateTopic.emit(this.topic)
    }
    this.modalService.dismissAll();
  }

}
