import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Comment } from 'src/models/comment';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private httpClient : HttpClient) { }

  getCommentById(id: number): Observable<Comment>{
    return this.httpClient.get<Comment>(`${environment.apiBaseUrl}/Comments/${id}`)
  }

  createComment(comment: Comment) {
    return this.httpClient.post(`${environment.apiBaseUrl}/Comments`, comment)
  }
}
