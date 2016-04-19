/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
    //config.language = 'vi';
    //config.skin = 'office2003';
    //config.uiColor = '#89C4F4';
    config.uiColor = '#7E7E81';

    config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files&currentFolder=/images/Upload/ImagesInPost/';
    config.filebrowserImageUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images&currentFolder=/images/Upload/ImagesInPost/';
    config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

};
