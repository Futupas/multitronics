/**
 * Created by ddl on 13.03.17.
 */
'use strict';

/**
 * Скрипт для странички товаров.
 * Отправляет GET запрос по адресу "/GetCategories"
 * получает JSON список категорий, и отображает их в виде кнопок (временно просто кнопок сверху).
 * По нажатию на любую из кнопок отправляет GET по адресу "/ProductsData?Category=XXX",
 * где XXX - ID нужной категории (в кнопке отображается имя, а по нажатию отправляется ID той,
 * которую выбрал пользователь).
 * Далее получает JSON всех товаров, и отображаете их.
 **/

'use strict';

var testJSON = {
	cat1: "cat1",
	cat2: "cat2"
};

testJSON = JSON.stringify(testJSON);

function getCategories(event) {
	event.preventDefault();
	var str = ($( testJSON ).serialize());
	$.ajax({
		url: '/GetCategories',
		type: 'GET',
		dataType: 'json',
		success: renderNavBtns,
		data: str
	});
}

function renderNavBtns() {
	console.log('render');
}

console.log(testJSON);