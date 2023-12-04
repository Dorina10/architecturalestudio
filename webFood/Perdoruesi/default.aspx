<%@ Page Title="" Language="C#" MasterPageFile="~/Perdoruesi/Perdoruesi.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webFood.Perdoruesi._default" %>
<%@ Import Namespace="webFood" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <!-- Facts Start -->
    <div class="container-xxl py-5">
        <div class="container pt-5">
            <div class="row g-4">
                <div class="col-lg-4 col-md-6 wow fadeInUp" data-wow-delay="0.1s">
                    <div class="fact-item text-center bg-light h-100 p-5 pt-0">
                        <div class="fact-icon">
                            <img src="../Template/images/icon-2.png" alt="Icon">
                        </div>
                        <h3 class="mb-3">Produkte cilësore</h3>
                        
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 wow fadeInUp" data-wow-delay="0.3s">
                    <div class="fact-item text-center bg-light h-100 p-5 pt-0">
                        <div class="fact-icon">
                            <img src="../Template/images/icon-3.png" alt="Icon">
                        </div>
                        <h3 class="mb-3">Staf i kualifikuar</h3>
                        
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 wow fadeInUp" data-wow-delay="0.5s">
                    <div class="fact-item text-center bg-light h-100 p-5 pt-0">
                        <div class="fact-icon">
                            <img src="../Template/images/icon-4.png" alt="Icon">
                        </div>
                        <h3 class="mb-3">Menaxhim projektesh</h3>
                
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Facts End -->


    <!-- About Start -->
    <div class="container-xxl py-5">
        <div class="container">
            <div class="row g-5">
                <div class="col-lg-6 wow fadeIn" data-wow-delay="0.1s">
                    <div class="about-img">
                        <img class="img-fluid" src="../Template/images/pexels-ksenia-chernaya-3965521.jpg"  alt="">
                        <img class="img-fluid" src="../Template/images/pexels-emre-can-acer-2079249.jpg"  alt="">
                    </div>
                </div>
                <div class="col-lg-6 wow fadeIn" data-wow-delay="0.5s">
                    <h4 class="section-title">RRETH NESH </h4>
                    <h1 class="display-5 mb-4"></h1>
                    <p>Ne jemi një skuadër arkitektësh dhe profesionistësh që realizojmë projektim të plotë, bashkëkohor dhe estetik të cdo ambienti të shtëpisë tuaj si dhe realizimin e mobiljeve nga një zdrukthtari profesionale. Ne ndjekim me kujdes cdo hap deri në montimin final të mobiljeve në shtëpite tuaja. Garancia jonë është cilësi dhe cmime konkurruese.</p>
                    <p class="mb-4">Stili i arredimit ka më shumë se 5 vjet që tregton dhe produkte outdoor, për të plotësuar kërkesën gjithnjë në rritje të instititucioneve dhe shoqatave të ndryshme për këto produkte në organizimin e aktiviteteve të tyre. Stafi ynë është gjithmonë i gatshëm tju ndihmoje dhe tju jap ide dhe zgjidhje</p>
                    <div class="d-flex align-items-center mb-5">
                        <div class="d-flex flex-shrink-0 align-items-center justify-content-center border border-5 border-primary" style="width: 120px; height: 120px;">
                            <h1 class="display-1 mb-n2" data-toggle="counter-up">5</h1>
                        </div>
                        <div class="ps-4">
                            <h3>vite</h3>
                            <h3>pune</h3>
                            <h3 class="mb-0">eksperiencë</h3>
                        </div>
                    </div>
                    <a class="btn btn-primary py-3 px-5" href="rrethnesh.aspx">Lexoni më shumë</a>
                </div>
            </div>
        </div>
    </div>
    <!-- About End -->

    
     
   <!-- ======= Our Portfolio Section ======= -->
    <section id="portfolio" class="portfolio section-bg">
      <div class="container" data-aos="fade-up" data-aos-delay="100">

        <div class="section-title">
          <h2>Portofoli</h2>
        </div>

        <div class="row">
          <div class="col-lg-12">
            <ul id="portfolio-flters">
              <li data-filter="*" class="filter-active">All</li>
              <li data-filter=".filter-app">Kuzhina</li>
              <li data-filter=".filter-card">Dhomë gjumi</li>
              <li data-filter=".filter-web">Dhomë ngrënje</li>
            </ul>
          </div>
        </div>

        <div class="row portfolio-container">

          <div class="col-lg-4 col-md-6 portfolio-item filter-app">
            <div class="portfolio-wrap">
              <img src="../Template/images/f1.jpg" class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-web">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-curtis-adams-3935317.jpg" class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-app">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-vecislavas-popa-1668860.jpg" class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-card">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-jean-van-der-meulen-1454806.jpg" class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-web">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-mark-mccammon-1080721%20(1).jpg"  class="img-fluid" alt="">
             
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-app">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-photomix-company-932095.jpg"  class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-card">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-max-rahubovskiy-6782567.jpg" class="img-fluid" alt="">
              
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-card">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-jonathan-borba-3144580.jpg" class="img-fluid" alt="">
             
            </div>
          </div>

          <div class="col-lg-4 col-md-6 portfolio-item filter-web">
            <div class="portfolio-wrap">
              <img src="../Template/images/pexels-jonathan-borba-3316918.jpg"  class="img-fluid" alt="">
              
            </div>
          </div>

        </div>

      </div>


        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

        <script>
            // Porfolio isotope and filter
            $(window).on('load', function () {
                var portfolioIsotope = $('.portfolio-container').isotope({
                    itemSelector: '.portfolio-item',
                    layoutMode: 'fitRows'
                });

                $('#portfolio-flters li').on('click', function () {
                    $("#portfolio-flters li").removeClass('filter-active');
                    $(this).addClass('filter-active');

                    portfolioIsotope.isotope({
                        filter: $(this).data('filter')
                    });
                });
        </script>
    </section><!-- End Our Portfolio Section -->
   
     <!-- Call To Action Section Begin -->
    <section class="callto spad set-bg" data-setbg="../Template/images/call-bg.jpg">
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-10 text-center">
                    <div class="callto__text">
                        <span>Pse ne?</span>
                        <h2>Aftësia jonë për të sjellë rezultate të jashtëzakonshme për klientët tanë.</h2>
                        <a href="rrethnesh.aspx" class="primary-btn py-3 px-5">Shiko më  shumë </a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Call To Action Section End -->
    <!-- ======= Our Team Section ======= -->
    <section id="team" class="team">
      <div class="container">

        <div class="section-title">
          <h2>Skuadra jonë</h2>
         
        </div>

        <div class="row">

          <div class="col-xl-3 col-lg-4 col-md-6" data-aos="fade-up">
            <div class="member">
              <div class="pic"><img src="../Template/images/dorina.jpg" class="img-fluid" alt=""></div>
              <div class="member-info">
                <h4>Dorina Sefullaj</h4>
                <span>CEO</span>
                <div class="social">
                  <a href=""><i class="icofont-twitter"></i></a>
                  <a href=""><i class="icofont-facebook"></i></a>
                  <a href=""><i class="icofont-instagram"></i></a>
                  <a href=""><i class="icofont-linkedin"></i></a>
                </div>
              </div>
            </div>
          </div>

          <div class="col-xl-3 col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
            <div class="member">
              <div class="pic"><img src="../Template/images/pexels-matheus-ferrero-1963075.jpg"  class="img-fluid" alt=""></div>
              <div class="member-info">
                <h4>Sarah Jhonson</h4>
                <span>Arkitekte</span>
                <div class="social">
                  <a href=""><i class="icofont-twitter"></i></a>
                  <a href=""><i class="icofont-facebook"></i></a>
                  <a href=""><i class="icofont-instagram"></i></a>
                  <a href=""><i class="icofont-linkedin"></i></a>
                </div>
              </div>
            </div>
          </div>

          <div class="col-xl-3 col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="200">
            <div class="member">
              <div class="pic"><img src="../Template/images/pexels-italo-melo-2379004.jpg"  class="img-fluid" alt=""></div>
              <div class="member-info">
                <h4>William Anderson</h4>
                <span>Arkitekt</span>
                <div class="social">
                  <a href=""><i class="icofont-twitter"></i></a>
                  <a href=""><i class="icofont-facebook"></i></a>
                  <a href=""><i class="icofont-instagram"></i></a>
                  <a href=""><i class="icofont-linkedin"></i></a>
                </div>
              </div>
            </div>
          </div>

          <div class="col-xl-3 col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="300">
            <div class="member">
              <div class="pic"><img src="../Template/images/pexels-engin-akyurt-1642228.jpg" class="img-fluid" alt=""></div>
              <div class="member-info">
                <h4>Amanda Jepson</h4>
                <span>Arkitekte</span>
                <div class="social">
                  <a href=""><i class="icofont-twitter"></i></a>
                  <a href=""><i class="icofont-facebook"></i></a>
                  <a href=""><i class="icofont-instagram"></i></a>
                  <a href=""><i class="icofont-linkedin"></i></a>
                </div>
              </div>
            </div>
          </div>

        </div>

      </div>
    </section>
    <!-- End Our Team Section -->
      
   
     
        <!--Vleresimet-->

    <section class="client_section layout_padding-bottom">
        <div class="container">
            <div class="heading_container heading_center psudo_white_primary mb_45">
                <h2>Vlerësimet e klientëve</h2>
                
            </div>
            <div class="carousel-wrap row ">
                <div class="owl-carousel client_owl-carousel">
                    <div class="item">
                        <div class="box">
                            <div class="detail-box">
                                <p>
                                    E rekomandoj plotësisht. Shërbim i shpejtë dhe produkte tepër cilësore.
                                </p>
                                <h6>Moena Luca
                                </h6>

                            </div>
                            <div class="img-box">
                                <img src="../Template/images/kliente1.jpg" alt="" class="box-img">
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <div class="box">
                            <div class="detail-box">
                                <p>
                                   10/10 Zgjedhja  e duhur për shtëpinë time,do tjua rekomandoja gjithkujt.
                                </p>
                                <h6>Aurel Lika
                                </h6>

                            </div>
                            <div class="img-box">
                                <img src="../Template/images/klient4.jpg" alt="" class="box-img">
                            </div>
                        </div>
                    </div>
                     <div class="item">
                        <div class="box">
                            <div class="detail-box">
                                <p>
                                   Studio arkitekturore më e mirë në Tiranë. I adhuroj produktet e tyre.
                                </p>
                                <h6>Era Gjonaj
                                </h6>

                            </div>
                            <div class="img-box">
                                <img src="../Template/images/kliente3.jpg" alt="" class="box-img">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- end client section -->
    

    <link href="../Template/css/StyleSheet1.css" rel="stylesheet" />

</asp:Content>
