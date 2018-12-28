/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
};
// �������ԣ�Ĭ��Ϊ 'en'
config.language = 'zh-cn';
// ���ÿ���
config.width = 400;
config.height = 400;
// �༭����ʽ�������֣�'kama'��Ĭ�ϣ���'office2003'��'v2'
config.skin = 'v2';
// ������ɫ
config.uiColor = '#FFF';
// ������������'Basic'��ȫ��'Full'���Զ��壩plugins/toolbar/plugin.js
config.toolbar = 'Basic';
config.toolbar = 'Full';
//�⽫��ϣ�
config.toolbar_Full = [
    ['Source', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
    ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Print', 'SpellChecker', 'Scayt'],
    ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
    ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
    '/',
    ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
    ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
    ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
    ['Link', 'Unlink', 'Anchor'],
    ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'],
    '/',
    ['Styles', 'Format', 'Font', 'FontSize'],
    ['TextColor', 'BGColor']
];
//�������Ƿ���Ա�����
config.toolbarCanCollapse = true;
//��������λ��
config.toolbarLocation = 'top';//��ѡ��bottom
//������Ĭ���Ƿ�չ��
config.toolbarStartupExpanded = true;
// ȡ�� ����ק�Ըı�ߴ硱���� plugins/resize/plugin.js
config.resize_enabled = false;
//�ı��С�����߶�
config.resize_maxHeight = 3000;
//�ı��С��������
config.resize_maxWidth = 3000;
//�ı��С����С�߶�
config.resize_minHeight = 250;
//�ı��С����С����
config.resize_minWidth = 750;
// ���ύ�����д˱༭���ı���ʱ���Ƿ��Զ�����Ԫ���ڵ�����
config.autoUpdateElement = true;
// ������ʹ�þ���Ŀ¼�������Ŀ¼��Ϊ��Ϊ���Ŀ¼
config.baseHref = ''
// �༭����z-indexֵ
config.baseFloatZIndex = 10000;
//���ÿ�ݼ�
config.keystrokes = [
    [CKEDITOR.ALT + 121 /*F10*/, 'toolbarFocus'],  //��ȡ����
    [CKEDITOR.ALT + 122 /*F11*/, 'elementsPathFocus'],  //Ԫ�ؽ���
    [CKEDITOR.SHIFT + 121 /*F10*/, 'contextMenu'],  //�ı��˵�
    [CKEDITOR.CTRL + 90 /*Z*/, 'undo'],  //����
    [CKEDITOR.CTRL + 89 /*Y*/, 'redo'],  //����
    [CKEDITOR.CTRL + CKEDITOR.SHIFT + 90 /*Z*/, 'redo'],  //
    [CKEDITOR.CTRL + 76 /*L*/, 'link'],  //����
    [CKEDITOR.CTRL + 66 /*B*/, 'bold'],  //����
    [CKEDITOR.CTRL + 73 /*I*/, 'italic'],  //б��
    [CKEDITOR.CTRL + 85 /*U*/, 'underline'],  //�»���
    [CKEDITOR.ALT + 109 /*-*/, 'toolbarCollapse']
]
//���ÿ�ݼ� �������������ݼ���ͻ plugins/keystrokes/plugin.js.
config.blockedKeystrokes = [
    CKEDITOR.CTRL + 66 /*B*/,
    CKEDITOR.CTRL + 73 /*I*/,
    CKEDITOR.CTRL + 85 /*U*/
]
//���ñ༭��Ԫ�صı���ɫ��ȡֵ plugins/colorbutton/plugin.js.
config.colorButton_backStyle = {
    element: 'span',
    styles: { 'background-color': '#(color)' }
}
//����ǰ��ɫ��ȡֵ plugins/colorbutton/plugin.js
//config.colorButton_colors = '000,800000,8B4513,2F4F4F,008080,000080,4B0082,696969,B22222,A52A2A,DAA520,006400,40E0D0,0000CD,800080,808080,F00,FF8C00,FFD700,008000,0FF,00F,EE82EE,A9A9A9,FFA07A,FFA500,FFFF00,00FF00,AFEEEE,ADD8E6,DDA0DD,D3D3D3,FFF0F5,FAEBD7,FFFFE0,F0FFF0,F0FFFF,F0F8FF,E6E6FA,FFF��

//�Ƿ���ѡ����ɫʱ��ʾ��������ɫ��ѡ�� plugins/colorbutton/plugin.js
config.colorButton_enableMore = false
//�����ǰ��ɫĬ��ֵ���� plugins/colorbutton/plugin.js
config.colorButton_foreStyle = {
    element: 'span',
    styles: { 'color': '#(color)' }
};
//����Ҫ���ӵ�CSS�ļ� �ڴ����� ��ʹ�����·������վ�ľ���·��
config.contentsCss = './contents.css';
//���ַ���
config.contentsLangDirection = 'rtl'; //������
//CKeditor�������ļ� ���������� ���ռ���
CKEDITOR.replace('myfiled', { customConfig: './config.js' });
//����༭��ı���ɫ plugins/dialog/plugin.js
config.dialog_backgroundCoverColor = '#fffefd'; //�����òο�
config.dialog_backgroundCoverColor = 'white' //Ĭ��
//�����Ĳ�͸���� ��ֵӦ���ڣ�0.0��1.0 ֮�� plugins/dialog/plugin.js
config.dialog_backgroundCoverOpacity = 0.5
//�ƶ����߸ı�Ԫ��ʱ �߿���������� ��λ������ plugins/dialog/plugin.js
config.dialog_magnetDistance = 20;
//�Ƿ�ܾ�����ƴд������ʾ Ĭ��Ϊ�ܾ� Ŀǰ��firefox��safari֧�� plugins/wysiwygarea/plugin.js.
config.disableNativeSpellChecker = true
//���б���༭���� �磺�����л��� Ŀǰ��firefox֧�� plugins/wysiwygarea/plugin.js
config.disableNativeTableHandles = true; //Ĭ��Ϊ������
//�Ƿ��� ͼƬ�ͱ��� �ĸı��С�Ĺ��� config.disableObjectResizing = true;
config.disableObjectResizing = false //Ĭ��Ϊ����
//����HTML�ĵ�����
config.docType = '<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd%22';
//�Ƿ�Ա༭���������Ⱦ plugins/editingblock/plugin.js
config.editingBlock = true;
//�༭���лس������ı�ǩ
config.enterMode = CKEDITOR.ENTER_P; //��ѡ��CKEDITOR.ENTER_BR��CKEDITOR.ENTER_DIV
//�Ƿ�ʹ��HTMLʵ�������� plugins/entities/plugin.js
config.entities = true;
//��������ʵ�� plugins/entities/plugin.js
config.entities_additional = '#39'; //����#������&
//�Ƿ�ת��һЩ������ʾ���ַ�Ϊ��Ӧ��HTML�ַ� plugins/entities/plugin.js
config.entities_greek = true;
//�Ƿ�ת��һЩ�����ַ�ΪHTML plugins/entities/plugin.js
config.entities_latin = true;
//�Ƿ�ת��һЩ�����ַ�ΪASCII�ַ� ��"This is Chinese: ����."ת��Ϊ"This is Chinese: ����." plugins/entities/plugin.js
config.entities_processNumerical = false;
//���������
config.extraPlugins = 'myplugin'; //��Ĭ�� ��ʾ��
//ʹ������ʱ�ĸ���ɫ plugins/find/plugin.js
config.find_highlight = {
    element: 'span',
    styles: { 'background-color': '#ff0', 'color': '#00f' }
};
//Ĭ�ϵ������� plugins/font/plugin.js
config.font_defaultLabel = 'Arial';
//����༭ʱ���ַ��� �������ӳ��õ������ַ������塢���塢����� plugins/font/plugin.js
config.font_names = 'Arial;Times New Roman;Verdana';
//���ֵ�Ĭ��ʽ�� plugins/font/plugin.js
config.font_style = {
    element: 'span',
    styles: { 'font-family': '#(family)' },
    overrides: [{ element: 'font', attributes: { 'face': null } }]
};
//����Ĭ�ϴ�С plugins/font/plugin.js
config.fontSize_defaultLabel = '12px';
//����༭ʱ��ѡ�������С plugins/font/plugin.js
config.fontSize_sizes = '8/8px;9/9px;10/10px;11/11px;12/12px;14/14px;16/16px;18/18px;20/20px;22/22px;24/24px;26/26px;28/28px;36/36px;48/48px;72/72px'
//���������Сʱ ʹ�õ�ʽ�� plugins/font/plugin.js
config.fontSize_style = {
    element: 'span',
    styles: { 'font-size': '#(size)' },
    overrides: [{ element: 'font', attributes: { 'size': null } }]
};
//�Ƿ�ǿ�Ƹ�����������ȥ����ʽ plugins/pastetext/plugin.js
config.forcePasteAsPlainText = false //��ȥ��
//�Ƿ�ǿ���á�&�������桰&amp;��plugins/htmldataprocessor/plugin.js
config.forceSimpleAmpersand = false;
//��address��ǩ���и�ʽ�� plugins/format/plugin.js
config.format_address = { element: 'address', attributes: { class: 'styledAddress' } };
//��DIV��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_div = { element: 'div', attributes: { class: 'normalDiv' } };
//��H1��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h1 = { element: 'h1', attributes: { class: 'contentTitle1' } };
//��H2��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h2 = { element: 'h2', attributes: { class: 'contentTitle2' } };
//��H3��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h1 = { element: 'h3', attributes: { class: 'contentTitle3' } };
//��H4��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h1 = { element: 'h4', attributes: { class: 'contentTitle4' } };
//��H5��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h1 = { element: 'h5', attributes: { class: 'contentTitle5' } };
//��H6��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_h1 = { element: 'h6', attributes: { class: 'contentTitle6' } };
//��P��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_p = { element: 'p', attributes: { class: 'normalPara' } };
//��PRE��ǩ�Զ����и�ʽ�� plugins/format/plugin.js
config.format_pre = { element: 'pre', attributes: { class: 'code' } };
//�÷ֺŷָ��ı�ǩ���� �ڹ���������ʾ plugins/format/plugin.js
config.format_tags = 'p;h1;h2;h3;h4;h5;h6;pre;address;div';
//�Ƿ�ʹ��������html�༭ģʽ ��ʹ�ã���Դ�뽫������<html><body></body></html>�ȱ�ǩ
config.fullPage = false;
//�Ƿ���Զ����еĿ��ַ� �������� ���ַ����ԡ�����ʾ plugins/wysiwygarea/plugin.js
config.ignoreEmptyParagraph = true;
//�����ͼƬ���Կ��е���������ʱ �Ƿ�ͬʱ������ߵ�<a>��ǩ plugins/image/plugin.js
config.image_removeLinkByEmptyURL = true;
//һ���ö��ŷָ��ı�ǩ���ƣ���ʾ�����½ǵĲ��Ƕ���� plugins/menu/plugin.js.
config.menu_groups = 'clipboard,form,tablecell,tablecellproperties,tablerow,tablecolumn,table,anchor,link,image,flash,checkbox,radio,textfield,hiddenfield,imagebutton,button,select,textarea';
//��ʾ�Ӳ˵�ʱ���ӳ٣���λ��ms plugins/menu/plugin.js
config.menu_subMenuDelay = 400;
//��ִ�С��½�������ʱ���༭���е����� plugins/newpage/plugin.js
config.newpage_html = '';
//����word�︴�����ֽ���ʱ���Ƿ�������ֵĸ�ʽ��ȥ�� plugins/pastefromword/plugin.js
config.pasteFromWordIgnoreFontFace = true; //Ĭ��Ϊ���Ը�ʽ
//�Ƿ�ʹ��<h1><h2>�ȱ�ǩ���λ��ߴ����word�ĵ���ճ������������ plugins/pastefromword/plugin.js
config.pasteFromWordKeepsStructure = false;
//��word��ճ������ʱ�Ƿ��Ƴ���ʽ plugins/pastefromword/plugin.js
config.pasteFromWordRemoveStyle = false;
//��Ӧ��̨���Ե��������������HTML���ݽ��и�ʽ����Ĭ��Ϊ��
config.protectedSource.push(/<"?["s"S]*?"?>/g);   // PHP Code
config.protectedSource.push( //g );   // ASP Code
    config.protectedSource.push(/(]+>["s|"S]*?<"/asp: [^ ">]+>)|(]+" />) / gi);   // ASP.Net Code
//�����룺shift+Enterʱ����ı�ǩ
config.shiftEnterMode = CKEDITOR.ENTER_P;  //��ѡ��CKEDITOR.ENTER_BR��CKEDITOR.ENTER_DIV
//��ѡ�ı�������ַ� plugins/smiley/plugin.js.
config.smiley_descriptions = [
    ':)', ':(', ';)', ':D', ':/', ':P',
    '', '', '', '', '', '',
    '', ';(', '', '', '', '',
    '', ':kiss', ''];
//��Ӧ�ı���ͼƬ plugins/smiley/plugin.js
config.smiley_images = [
    'regular_smile.gif', 'sad_smile.gif', 'wink_smile.gif', 'teeth_smile.gif', 'confused_smile.gif', 'tounge_smile.gif',
    'embaressed_smile.gif', 'omg_smile.gif', 'whatchutalkingabout_smile.gif', 'angry_smile.gif', 'angel_smile.gif', 'shades_smile.gif',
    'devil_smile.gif', 'cry_smile.gif', 'lightbulb.gif', 'thumbs_down.gif', 'thumbs_up.gif', 'heart.gif',
    'broken_heart.gif', 'kiss.gif', 'envelope.gif'];
//����ĵ�ַ plugins/smiley/plugin.js
config.smiley_path = 'plugins/smiley/images/';
//ҳ������ʱ���༭���Ƿ�������ý��� plugins/editingblock/plugin.js plugins/editingblock/plugin.js.
config.startupFocus = false;
//����ʱ���Ժ��ַ�ʽ�༭ Դ������������� "source"��"wysiwyg" plugins/editingblock/plugin.js.
config.startupMode = 'wysiwyg';
//����ʱ���Ƿ���ʾ����ı߿� plugins/showblocks/plugin.js
config.startupOutlineBlocks = false;
//�Ƿ�������ʽ�ļ� plugins/stylescombo/plugin.js.
config.stylesCombo_stylesSet = 'default';
//����Ϊ��ѡ
config.stylesCombo_stylesSet = 'mystyles';
config.stylesCombo_stylesSet = 'mystyles:/editorstyles/styles.js';
config.stylesCombo_stylesSet = 'mystyles:http://www.example.com/editorstyles/styles.js';
//��ʼ������ֵ
config.tabIndex = 0;
//���û�����TABʱ���༭���߹��Ŀո�����(&nbsp;) ��ֵΪ0ʱ�����㽫�Ƴ��༭�� plugins/tab/plugin.js
config.tabSpaces = 0;
//Ĭ��ʹ�õ�ģ�� plugins/templates/plugin.js.
config.templates = 'default';
//�ö��ŷָ���ģ���ļ�plugins/templates/plugin.js.
config.templates_files = ['plugins/templates/templates/default.js']
//��ʹ��ģ��ʱ�����༭���ݽ����滻�����Ƿ�ѡ�� plugins/templates/plugin.js
config.templates_replaceContent = true;
//����
config.theme = 'default';
//�����ļ�¼���� plugins/undo/plugin.js
config.undoStackSize = 20;
    // �� CKEditor �м��� CKFinder��ע�� ckfinder ��·��ѡ��Ҫ��ȷ��
    //CKFinder.SetupCKEditor(null, '/ckfinder/');