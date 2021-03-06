import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CommunityService} from '../../services/community/CommunityService';

@Component({
  selector: 'app-create-community',
  templateUrl: './create-community.component.html',
  styleUrls: ['./create-community.component.scss']
})
export class CreateCommunityComponent implements OnInit {
  createFrom: FormGroup;
  formError = '';

  constructor(private formBuilder: FormBuilder, private router: Router, private communityService: CommunityService) {
    this.createFrom = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      description: ['', [Validators.required, Validators.minLength(3)], Validators.maxLength(500)],
      headImageUrl: ['', [Validators.required]],
      coverImageUrl: ['']
    });
  }

  get name() {
    return this.createFrom.get('name');
  }

  get description() {
    return this.createFrom.get('description');
  }

  get headImageUrl() {
    return this.createFrom.get('headImageUrl');
  }

  get coverImageUrl() {
    return this.createFrom.get('coverImageUrl');
  }

  ngOnInit(): void {
  }

  create(): void {
    if (this.createFrom.invalid) {
      return;
    }

    if (this.name.value.includes(' ')) {
      this.formError = 'Name should be only one word';
      return;
    }

    if (!this.headImageUrl.value.startsWith('https://')) {
      this.formError = 'Head Image Url should start with "https://"';
      return;
    }

    if (this.coverImageUrl.value && !this.coverImageUrl.value.startsWith('https://')) {
      this.formError = 'Cover Image Url should start with "https://"';
      return;
    }

    this.communityService.createCommunity(this.createFrom.value)
      .subscribe(() => this.router.navigate(['/']), err => this.formError = err.error.error);
  }
}
